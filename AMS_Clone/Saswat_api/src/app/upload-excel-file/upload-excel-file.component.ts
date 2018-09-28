import { Component, OnInit, HostListener,OnDestroy } from '@angular/core';
import { MindsService } from "src/app/shared/minds.service";
import {UserService} from '../shared/user.service';
import {Router} from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
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
  selector: "app-upload-excel-file",
  templateUrl: "./upload-excel-file.component.html",
  styleUrls: ["./upload-excel-file.component.css"]
})
export class UploadExcelFileComponent implements OnInit {
  fileToUpload: File = null;
  myFiles: File[] = [];
  isUploading = true;

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
  disableUploadreg=0;

  ngOnDestroy(){
    this.Logout();
  }
  @HostListener('window:beforeunload', ['$event'])
  onbeforeunloadHandler(event) {
    event.returnValue = "this worked";
   this.Logout();
     // console.log("it has removed your session")
      window.sessionStorage.removeItem("userToken");
  }
  ngOnInit() {
  }
  /* handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);
  }
  OnSubmit(FileTo) {
    this.imageService.postFile(this.fileToUpload).subscribe();
  }*/
  onFileChangereg(evt: any) {
    /* wire up file reader */
    const target: DataTransfer = <DataTransfer>evt.target;
    if(target.files[0].type != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
    {
      this.disableUploadreg=0; 
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
    this.disableUploadreg=1;
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

  uploadfile() {
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
    this.imageService.onUpload(resArr).subscribe(
     
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

  uploadCMfile() {
    this.disableUpload=0;
    let keys = this.data.shift();
    let resArrcm = this.data.map(e => {
    let obj = {};
    keys.forEach((key, i) => {
    obj[key] = e[i];
    });
    return obj;
    });
    console.log(resArrcm);
    //const _data = resArr;
    this.imageService.OnCMUpload(resArrcm).subscribe(
    x => {
    if (x.ok) {
    Swal({
    position: "center",
    type: "success",
    title: "Your file has been uploaded successfully!!!",
    showConfirmButton: false,
    timer: 5000
    });
    }
    },
    err => {
    this.resetFileUploader();
    Swal({
    position: "center",
    type: "error",
    title: "Upload Failed!!! Choose again!!",
    showConfirmButton: false,
    timer: 5000
    });
    }
    );
    } 

    //File array 
  getFileDetails (e) {
    console.log (e);
    for (let i = 0; i < e.length; i++) {
      this.myFiles.push(e[i]);
    }
  }

  //Post files on submit button click
  uploadFiles () {
    const frmData = new FormData();
    for (let i = 0; i < this.myFiles.length; i++) {
        console.log (this.myFiles[i]);
        frmData.append('Image', this.myFiles[i], this.myFiles[i].name);
      }
     this.imageService.postImage(frmData).subscribe(data => {
       this.isUploading = false;
       Swal({
         position: 'center',
         type: 'success',
         text: 'Uploaded Files Successfully'
       });
       for (let counter = 0; counter < this.myFiles.length; counter++) {
        this.myFiles.pop();
       }
     });
       } else
        if (data.status == 404) {
          Swal({
            position: 'center',
            type: 'error',
            text: 'Could not upload files',
            showConfirmButton: false,
            timer: 4000
          });
        } else
        if (data.status == 206) {
          Swal({
            position: 'center',
            type: 'error',
            text: 'No Images Found',
            showConfirmButton: false,
            timer: 4000
          });
        } else
        if (data.status == 403) {
          Swal({
            position: 'center',
            type: 'error',
            text: 'Connection closed with server',
            showConfirmButton: false,
            timer: 4000
          });
        }
      },
      err => {
        this.resetFileUploader();
        Swal({
          position: "center",
          type: "error",
          title: "Upload Failed!!! Choose valid file Or Rename the file",
          showConfirmButton: false,
          timer: 5000
        });
    });
  }
  //calls the service to logout the user
  Logout(){
    this.userServ.userLogout().subscribe((data:any) =>{
      sessionStorage.removeItem("userToken");
    this.router.navigate(["./login"]);
    });
  }
}
