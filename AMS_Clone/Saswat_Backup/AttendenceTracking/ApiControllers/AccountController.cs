
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Tracking.DataAccessLayer.DbContext;
using ITracking.Bussiness;
using Tracking.Entities;
using System.Threading.Tasks;
using Tracking.Business;
using Microsoft.Owin.Security.OAuth;
using System.IO;
using System.Web.Http.Cors;

namespace Tracking.Controllers
{
    public class AccountController : ApiController
    {
        
        private readonly ITrackingBusiness itrack;
        public AccountController(ITrackingBusiness track) {
            itrack = track;
        }


        [HttpPost]
        [Route("api/SendCode")]
        public async Task<HttpResponseMessage> SendCode([FromBody]EmailModel model) {

            /*creates a random string for the user's reset code
             Then, the this method calls the
             interface to send the email through the Email Handler*/
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            ApplicationUser user = await store.FindByEmailAsync(model.GivenEmail);
            if (user == null)
            {

                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No User Found With The Given Email")),
                    ReasonPhrase = "Email Not Recognized"
                };
                throw new HttpResponseException(response);
            }
            String random = Path.GetRandomFileName();
            String resetCode = random.Replace(".", "");

            await itrack.SendNewCode(model.GivenEmail, resetCode);
            return this.Request.CreateResponse(HttpStatusCode.OK, resetCode);
        }
        //http method for reseting the user's password 
        [HttpPost]     
        [Route("api/ResetPassword")]
        public async Task<IHttpActionResult> ResetPassword([FromBody]ResetModel model) {
            //sets the users new password. taking in the user's input and hashing it,
            //then storing it in the database 
            //first, the database is called and the user associtated with the given email is found
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = await store.FindByEmailAsync(model.GivenEmail);

            if (model.newPassword.Length < 8)
            {

                var errMessage = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(string.Format("Password not excepted")),
                    ReasonPhrase = "Password not long enough"
                };
                throw new HttpResponseException(errMessage);
            }
            //hashes the given password, then stores the encryption in the database. 
            //the user db is then updated. 
            String hashedNewPassword = UserManager.PasswordHasher.HashPassword(model.newPassword);
            await store.SetPasswordHashAsync(user, hashedNewPassword);
            await store.UpdateAsync(user);
            return Ok();
        }


        //http method for user log out
        [HttpGet]
        [Authorize]
        [Route("api/Logout")]
        public async Task<IHttpActionResult> Logout() {
            //calls the database and identifies the current user.    
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
            var current = System.Web.HttpContext.Current.User.Identity;
            var identityClaims = (ClaimsIdentity)current;
            var username = identityClaims.FindFirst("Username").Value;
            var user = userManager.FindByName(username);
            if (!current.IsAuthenticated)
            {
                var errMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(string.Format("Cannot Fulfill Logout Request")),
                    ReasonPhrase = "Authorization Not Recognized"
                };
                throw new HttpResponseException(errMessage);
            }
            //sets the current user's IsLogged status to zero. 
            user.IsLogged = 0;
            await userStore.UpdateAsync(user);
            return Ok();
        }


        //http response for getting the user's role
        [HttpGet]
        [Route("api/GetRoles")]
        public HttpResponseMessage GetRoles() {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var roles = roleManager.Roles.Select(x => new { x.Id, x.Name }).ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, roles);
        }



    }
}
