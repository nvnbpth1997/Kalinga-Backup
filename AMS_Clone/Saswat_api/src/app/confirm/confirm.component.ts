import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from "../shared/user.service";
import { HttpErrorResponse } from "@angular/common/http";
import {Router} from "@angular/router";
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {ToastrService} from 'ngx-toastr';
import { ResetPasswordComponent } from './../reset-password/reset-password.component';


export interface DialogData {
  email: string;
  newPassword: string;
}

@Component({
  selector: "app-confirm",
  templateUrl: "./confirm.component.html"
})
export class ConfirmComponent {
  constructor(
    public dialogRef: MatDialogRef<ConfirmComponent>,
    private userServ: UserService,
    private toast: ToastrService,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}

  ChangePassword(newPassword, email) {
    this.userServ.resetPassword(email, newPassword).subscribe(
      (data: any) => {
        /*if the the email succeeds, then the user will be redirected to login otherwise, 
        an error message will appear
      */ this.dialogRef.close();
      },
      (err: HttpErrorResponse) => {
        this.toast.error(err.error);
      }
    );
  }
}
