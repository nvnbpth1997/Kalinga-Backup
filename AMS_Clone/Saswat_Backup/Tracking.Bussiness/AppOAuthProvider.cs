using Tracking.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Tracking.DataAccessLayer.DbContext;
using System.Net.Http;
using System.Net;

namespace Tracking.Business
{
    public class AppOAuthProvider : OAuthAuthorizationServerProvider
    {

        //validates the client 
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        //authenticates the user and creates the validation token for that user upon login using the provided credentials
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
          
                //first, call the database and see if the user exists, and to check to make sure that they are not already logged in
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = await userManager.FindAsync(context.UserName, context.Password);

            /*if they do exists, and are not already logged in, then create an identityclaim 
             * and a login token for that user. the claim will be used for calling data associated
             * with the currently logged-in user
             */
            if (user != null && user.IsLogged != 1)
            {
                //claims include their role, username, and email address
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Username", user.UserName));
                identity.AddClaim(new Claim("Email", user.Email));
                var userRoles = userManager.GetRoles(user.Id);
                foreach (string roleName in userRoles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, roleName));
                }

                var role = new AuthenticationProperties(new Dictionary<string, string>{{
                "role", Newtonsoft.Json.JsonConvert.SerializeObject(userRoles)
                }});

                //create and validate the token, then update the user's loggin status
                var token = new AuthenticationTicket(identity, role);
                context.Validated(token);
                user.IsLogged = 1;
                await userStore.UpdateAsync(user);
            }

            //if the user does not exist return this message
            else if (user == null)
            {
                var errMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("User Not Found")),
                    ReasonPhrase = "Incorrect User Name Or Password"
                };
                throw new HttpResponseException(errMessage);
            }



            //otherwise, (which means that the user is already logged in) send this message
            else
            {
                var errMessage = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(string.Format("Access Denied")),
                    ReasonPhrase = "You are Trying to sign into an account"
                };
                throw new HttpResponseException(errMessage);
            }

        }
        
        //returns the token to the client 
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
             foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
             {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
             }
             return Task.FromResult<object>(null);
        }
    }
}