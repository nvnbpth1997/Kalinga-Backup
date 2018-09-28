import { Component, OnDestroy, HostListener } from '@angular/core';
import { BreakpointObserver, Breakpoints, BreakpointState } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import {UserService} from '../shared/user.service';
import {Router} from "@angular/router";

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );
    
  constructor(private breakpointObserver: BreakpointObserver, private router: Router, private userServ: UserService) {}
  
  ngOnDestroy(){
    this.Logout();
  }
  @HostListener('window:beforeunload', ['$event'])
  onbeforeunloadHandler(event) {
   this.Logout();
     // console.log("it has removed your session")
      window.sessionStorage.removeItem("userToken");
  }

  Logout(){
    this.userServ.userLogout().subscribe((data : any)=>{
      /*if the email succeeds, then the 
      user will be redirected to login otherwise, 
      an error message will appear
      */
    //  console.log(data);
      this.router.navigate(['/login']); 
      sessionStorage.removeItem("userToken");   
    });;
  }
  }

 
