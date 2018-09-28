
import { Component, OnInit, HostListener,OnDestroy } from '@angular/core';
import { MindsService } from "src/app/shared/minds.service";
import {UserService} from '../shared/user.service';
import {Router} from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import {NgModule} from'@angular/core';
import Swal from 'sweetalert2';
import {
  BreakpointObserver,
  Breakpoints,
  BreakpointState
} from "@angular/cdk/layout";
import * as XLSX from "xlsx";
import { ElementRef } from '@angular/core';
import { ViewChild } from '@angular/core';
@Component({
  selector: "app-upload-excused-excel",
  templateUrl: "./upload-excused-excel.component.html",
  styleUrls: ["./upload-excused-excel.component.css"]
})
@Component({
  selector: 'app-upload-excused-excel',
  templateUrl: './upload-excused-excel.component.html',
  styleUrls: ['./upload-excused-excel.component.css']
})
export class UploadExcusedExcelComponent implements OnInit {
  fileToUpload: File = null;
  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(map(result => result.matches));

  constructor(
    private imageService: MindsService,
    private router: Router,
    private userServ: UserService,
    private breakpointObserver: BreakpointObserver
  ) {}

  @ViewChild('fileuploader') fileUploader:ElementRef;

  resetFileUploader() { 
    this.fileUploader.nativeElement.value = null;
  } 

  data = [];
  // public showConfirmButton: boolean;
  disableUpload=0;

 
  ngOnInit() {
  }
  /* handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);
  }
  OnSubmit(FileTo) {
    this.imageService.postFile(this.fileToUpload).subscribe();
  }*/
  onFileChange(evt: any) {
    /* wire up file reader */
    const target: DataTransfer = <DataTransfer>evt.target;
    if(target.files[0].type != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
    {
      this.disableUpload=0; 
      Swal({
        position: 'center',
        type: 'error',
        title: 'Invalid format',
        text: 'only xlsx format is accepatable',
        showConfirmButton: false,
        timer: 4000
      })
    }
   else if (target.files.length == 1 && evt.target.accept === "xlsx") {
    this.disableUpload=1;
      const reader: FileReader = new FileReader();
      reader.onload = (e: any) => {
        /* read workbook */
        const bstr: string = e.target.result;
        const wb: XLSX.WorkBook = XLSX.read(bstr, { type: "binary", cellDates: true, cellNF: false, cellText:false });
        console.log(wb);
        /* grab first sheet */
        const wsname: string = wb.SheetNames[0];
        const ws: XLSX.WorkSheet = wb.Sheets[wsname];
        /* save data */
        const format = "M/D/YYYY h:mm:ss";
        this.data = <any>XLSX.utils.sheet_to_json(ws, { header: 1 , dateNF:format });
      };
      reader.readAsBinaryString(target.files[0]);
    }
  }

  uploadexcusedfile() {
    this.disableUpload=0;
    let keys = this.data.shift();
    let resArr = this.data.map(e => {
      let obj = {};
      keys.forEach((key, i) => {
        obj[key] = e[i];
      });
      return obj;
    });
    console.log(resArr);
    //const _data  = resArr;
    this.imageService.onExcuseUpload(resArr).subscribe(
     
      x => {
       
        if (x.ok) {
          
          Swal({
            position: "center",
            type: "success",
            title: "Your file has been uploaded successfully!!!",
            showConfirmButton: false,
            timer: 5000
          });
        }
      },
      err => {
        this.resetFileUploader();
        Swal({
          position: "center",
          type: "error",
          title: "Upload Failed!!! Choose again!!",
          showConfirmButton: false,
          timer: 5000
        });
      }
    );
  }
  //calls the service to logout the user
  Logout(){
    this.userServ.userLogout().subscribe((data:any) =>{
      sessionStorage.removeItem("userToken");
    this.router.navigate(["./login"]);
    });
  }
}
