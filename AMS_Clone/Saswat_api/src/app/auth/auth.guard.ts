import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import {UserService} from '../shared/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router : Router, private userServ : UserService){}
    /*
   canActivate is used to match the roles provided by the data
   with the known user roles. and dictates what happens when 
   a users without proper authorization tries to access 
   a protected page , if the rolesmatch, then return true
   otherwise, return false, and reroute to 'access denied' page. 
   if no data is provided at all, then simple rerout to login
  */
  canActivate(
      next: ActivatedRouteSnapshot,
     
    state: RouterStateSnapshot):  boolean 
    {
      if (sessionStorage.getItem('userToken') != null)
      {
        console.log(next);
        // if the user has a token
        let roles = next.data["roles"] as Array<string>;
           /*if roles isnt null, 
        and users role matches, return true,
        otherwise return false
        */
        if (roles) 
        {
          var authorized = this.userServ.roleMatch(roles);
          console.log(authorized);
          if (authorized) {
            return true;
          }
          else {
            this.router.navigate(['/denied_access']);
            return false;
          }
        }
        else{
          return true;
        }
      }
        this.router.navigate(['/login']);
        return false;
    }
}