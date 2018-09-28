import { Component, OnInit } from "@angular/core";
import { UserService } from "../shared/user.service";
import { HttpErrorResponse } from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  signInError : boolean = false;
  constructor(private userServ : UserService,private router : Router) { }
 
  ngOnInit() {
  }
  /*if the user's credentials are legitimate and the user
    is authenticated, than the user's access-token and
    authorization-role are stored. also, the user is
    redirected to a new page depending on their "role".
    Otherwise, and error message is returned, which is 
    handled by the signInError method.
  */
  onSubmit(userName,password){
   // console.log("hello");
     this.userServ.authenticateUser(userName,password).subscribe((data : any)=>{
      sessionStorage.setItem('userToken',data.access_token);
      localStorage.setItem('userRoles',data.role);
      console.log(data.role);
      console.log(data.access_token);
      if(data.role.indexOf("CIS") > -1)
      {       
       // console.log("hello5");
        this.router.navigate(['home/upload-excel-file']);
      }
      else if(data.role.indexOf("PF") > -1)
      {
        //console.log("hello6");
      this.router.navigate(["/home/swiped-not-on-time"]);
      }    
    },
    (err : HttpErrorResponse)=>{
      this.signInError = true;
    });
  }
  forgotPassword() {
    this.router.navigate(['/reset-password']);
};
 
}
