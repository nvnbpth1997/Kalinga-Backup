import { NgxPaginationModule } from 'ngx-pagination';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{RouterModule, Routes} from '@angular/router';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomepageComponent } from './homepage/homepage.component';
import { LayoutModule } from '@angular/cdk/layout';
import { UserService } from './shared/user.service';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule, MatGridListModule, MatCardModule } from '@angular/material';
import { MatCheckboxModule, MatMenuModule, MatInputModule } from '@angular/material';
import { MindsService } from "src/app/shared/minds.service";
import { AuthGuard } from './auth/auth.guard';
import { HttpClientModule } from "@angular/common/http";
import {MatDialogModule} from '@angular/material/dialog';
import { HttpModule } from "@angular/http";
import {MatTabsModule} from '@angular/material/tabs';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { SignInComponent } from './sign-in/sign-in.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { UserComponent } from './user/user.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ToastrModule } from 'ngx-toastr';
import * as XLSX from "xlsx";
import { UploadExcusedExcelComponent } from './upload-excused-excel/upload-excused-excel.component';
import { SettingsComponent } from './settings/settings.component';
import { ConfirmComponent } from './confirm/confirm.component';

//import { AdminMenuComponent } from './admin-menu/admin-menu.component';
//import { ReaderMenuComponent } from './reader-menu/reader-menu.component';
//import { ForbiddenComponent } from './forbidden/forbidden.component';

/*const appRoutes:Routes=[
      {path:' ',redirectTo:'/swiped-not-on-time',pathMatch:'full'}, 
      {path: 'upload-excel-file', component: UploadExcelFileComponent},
      {path:'swiped-on-time',component:SwipedOnTimeComponent},
      {path:'swiped-not-on-time',component:SwipedNotOnTimeComponent},
      {path:'not-swiped',component:NotSwipedComponent},
      {path:'logout',component:LogoutComponent},
      {path: '**', component: PageNotFoundComponent}  
];*/
@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
   // SwipedOnTimeComponent,
   // SwipedNotOnTimeComponent,
   // NotSwipedComponent,
   // UploadFileComponent,
   // LogoutComponent,
   // UploadExcelFileComponent,
     routingComponents,
   SignInComponent,
   ResetPasswordComponent,
   UserComponent,
   UploadExcusedExcelComponent,
   SettingsComponent,
   ConfirmComponent
    // PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    // RouterModule.forRoot(appRoutes),
    LayoutModule,
    NgxPaginationModule,
    MatCheckboxModule, 
    MatMenuModule,
    MatInputModule,
    MatToolbarModule,
    MatDialogModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    HttpClientModule,
    HttpModule,
    MatCardModule,
    MatGridListModule,
    FormsModule,
    FlexLayoutModule,
    MatTabsModule,
    AppRoutingModule,
    ToastrModule.forRoot()
  
  ],
  providers: [MindsService,UserService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

