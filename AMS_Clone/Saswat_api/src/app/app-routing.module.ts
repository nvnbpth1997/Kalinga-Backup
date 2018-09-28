import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { SwipedOnTimeComponent } from "src/app/swiped-on-time/swiped-on-time.component";
import { SwipedNotOnTimeComponent } from "src/app/swiped-not-on-time/swiped-not-on-time.component";
import { NotSwipedComponent } from "src/app/not-swiped/not-swiped.component";
//import {NgxPaginationModule} from "ngx-pagination";
// import { LogoutComponent } from './logout/logout.component';
import { UploadExcelFileComponent } from './upload-excel-file/upload-excel-file.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import {HomepageComponent} from './homepage/homepage.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './sign-in/sign-in.component';
import {UploadExcusedExcelComponent} from './upload-excused-excel/upload-excused-excel.component';
//import {AdminMenuComponent} from './admin-menu/admin-menu.component';
//import {ReaderMenuComponent} from './reader-menu/reader-menu.component';
import {AuthGuard} from './auth/auth.guard';
//import {ForbiddenComponent} from './forbidden/forbidden.component';
import {ResetPasswordComponent} from './reset-password/reset-password.component';
import { MindDetailsComponent } from "./mind-details/mind-details.component";
import { SettingsComponent } from "src/app/settings/settings.component";

const routes: Routes = [
      {path: '', redirectTo: '/login', pathMatch: 'full'}, 
      {path: 'home/upload-excel-file', component: UploadExcelFileComponent,canActivate: [AuthGuard], data: {roles:['CIS']}},
      { path: 'login', component: UserComponent, children: [{ path: '', component: SignInComponent }]},
      { path : '', redirectTo:'/login', pathMatch : 'full'},
      { path: 'reset-password', component: ResetPasswordComponent},
      {path: 'home', component: HomepageComponent, canActivate: [AuthGuard], data: {roles:['PF']},
    //  { path: 'adminmenu', component: AdminMenuComponent, canActivate: [AuthGuard] , data: { roles: ['PF']}},
     // { path: 'readmenu', component: ReaderMenuComponent, canActivate: [AuthGuard] , data: { roles: ['CIS'] }},
     // { path: 'denied_access', component: ForbiddenComponent, canActivate: [AuthGuard] },
      children: [
      {path: 'swiped-on-time', component: SwipedOnTimeComponent},
      {path: 'swiped-not-on-time', component: SwipedNotOnTimeComponent},
      {path: 'not-swiped', component: NotSwipedComponent},
      {path: 'details/:mid', component: MindDetailsComponent},
      {path: 'upload-excused-excel',component: UploadExcusedExcelComponent},
      {path: 'settings', component: SettingsComponent}
    ]},
      // {path: 'home/logout', component: LogoutComponent},
      {path: '**', component: PageNotFoundComponent}
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
// Good Practice
export const routingComponents = [ SwipedOnTimeComponent,
    SwipedNotOnTimeComponent,
    NotSwipedComponent,
    // LogoutComponent,
    UploadExcelFileComponent,
    PageNotFoundComponent,
    MindDetailsComponent];
