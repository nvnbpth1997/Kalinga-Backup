import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import {Http,Headers,Response, } from "@angular/http";
import {Observable} from "rxjs";
import { map } from "rxjs/operators";
import { User } from "./user.model";
import { HttpParams } from "@angular/common/http";
@Injectable({
  providedIn: "root"
})
export class UserService {
readonly url = "http://localhost:64483"; 
//  readonly url = "https://amsapijun18dotnet.azurewebsites.net"; 
  constructor(private http: HttpClient) {}

  /*in order to authenticate the user, this function will create return a token 
  request based on the credentials entered.
  */
  authenticateUser(userName, password) {
    //console.log("hello2");
    const data = new HttpParams()
      .set("username", userName)
      .set("password", password)
      .set("grant_type", "password");

    var reqHeader = new HttpHeaders()
      .set("Content-Type", "application/x-www-form-urlencoded")
      .set("Access-Control-Allow-Origin", "*");
    //console.log( this.url + data + reqHeader );
    return this.http.post(this.url + "/token", data, { headers: reqHeader });
  }

  /*
  this method creates a registration request to ensure that a user can register a new
  account. 
  */
  registerUser(user: User, roles: string[]) {
    const body = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName,
      Roles: roles
    };
    // console.log(user);
    // console.log(body);
    var reqHeader = new HttpHeaders({ "No-Auth": "True" });
    return this.http.post(this.url + "/api/User/Register", body, {
      headers: reqHeader
    });
  }

  /*checks to make sure that user's role matches
the one that is allowed authorization. if they 
do match, return true, otherwise, return false.
*/ 
  roleMatch(allowedRoles): boolean {
    var isMatch = false;
    var userRoles: string[] = JSON.parse(localStorage.getItem("userRoles"));
    allowedRoles.forEach(element => {
      if (userRoles.indexOf(element) > -1) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }

  //retrieves roles from database

  getRoles() {
    var reqHeader = new HttpHeaders({ "No-Auth": "True" });
    return this.http.get(this.url + "/api/GetRoles", { headers: reqHeader });
  }

  //http request to email a reset code 
  sendCode(userEmail) {
    const data = new HttpParams()
    .set("GivenEmail", userEmail);
    //sets the userEmail as the parameter to be passed     
    //no authorization needed, the email is enough 
    var reqHeader = new HttpHeaders({ "No-Auth": "True" });
    //returns request 
    return this.http.post(this.url + "/api/SendCode", data,{ headers: reqHeader }); 
  }

  //http post request for resetting password
  resetPassword(userEmail,newPassword) {
    //sets the userEmail and password as the parameter to be passed 
    const data = new HttpParams().set("GivenEmail", userEmail);
    //no authorization needed, the email is enough 
    var reqHeader = new HttpHeaders({ "No-Auth": "True" });
    //returns request 
    return this.http.post(this.url + "/api/ResetPassword", data, { headers: reqHeader }); 
  }

  userLogout() {
    //no authorization needed, the email is enough 
    var reqHeader = new HttpHeaders({'Authorization' : 'Bearer ' + sessionStorage.getItem('userToken')})
    //returns request 
    return this.http.get(this.url + "/api/Logout", { headers: reqHeader });
  }
}
