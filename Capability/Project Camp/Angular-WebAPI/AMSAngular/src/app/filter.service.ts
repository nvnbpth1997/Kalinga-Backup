import { Image } from './image';
import { Router } from '@angular/router';
import { Mind } from './mind';
import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as XLSX from 'xlsx';
import * as FileSaver from 'file-saver';
import { Observable } from 'rxjs';
import { HttpEvent } from '@angular/common/http';
import { HttpRequest } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FilterService implements OnInit {

  image: Image = {
    ID: null,
    ImageName: null,
    ImageURL: null
  };

  images: Image[];
  minds: Mind[];
  value = 0;
  fromDate: DateTimeFormat;
  toDate: DateTimeFormat;


  EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
  EXCEL_EXTENSION = '.xlsx';

  mind: Mind = {
    ID: null,
    FirstName: '',
    LastName: '',
    Email: '',
    MID: '' ,
    Mobile: '',
    Gender: '',
    SwipeInTime: '',
    SwipeStatus: null,
    Day: null,
    image: null
  };

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

    postFile(formData: FormData) {
      return this.http.post('http://localhost:55631/api/Images', formData);
    }

  //   mix() {
  //     for (let i = 0; i < this.minds.length; ++i) {
  //        for (let j = 0; j < this.images.length; ++j) {
  //          if (this.minds[i].MID + '.jpg' == this.images[i].ImageName) {
  //              this.minds[i].image = this.images[i];
  //          } else {
  //           this.minds[i].image = null;
  //          }
  //        }
  //     }
  //  }
    // getImage(mid) {
    //   return this.http.get('http://localhost:55631/api/Images/Download/' + mid)
    //   .subscribe((x: Image) => (this.image = x));
    // }

    getImages() {
      return this.http.get('http://localhost:55631/api/Images')
      .subscribe((x: Image[]) => {(this.images = x);   console.log(this.minds);  });
    }

  getDetails(value: number) {
      this.http.get('http://localhost:55631/api/AMSModels/BySwipe/' + value)
      .subscribe((x: Mind[]) => (this.minds = x));
    }

    getAllDetails() {
      this.http.get('http://localhost:55631/api/AMSModels')
      .subscribe( (x: Mind[]) => this.minds = x);
    }

    getEmployee(id: number) {
      this.http.get('http://localhost:55631/api/AMSModels/' + id)
      .subscribe((x: Mind) => this.mind = x );
    }

    getDefaultDetails() {
      this.http.get('http://localhost:55631/api/AMSModels/ByDefaulter')
      .subscribe((x: Mind[]) => (this.minds = x));
    }

    getTrackDetails() {
      if (this.value === 0) {
              // this.router.navigate(['/Repeated-Defaulter']);
              this.getDefaultDetails();
          } else {
      this.http.get('http://localhost:55631/api/AMSModels/ByDefaulterTrack/' + this.value)
      .subscribe((x: Mind[]) => (this.minds = x));
            }
    }

    getTrackByDate() {
      console.log(this.fromDate, this.toDate);
      this.http.get('http://localhost:55631/api/AMSModels/ByDefaulterDateTrack/' + this.fromDate + '/' + this.toDate)
      .subscribe((x: Mind[]) => (this.minds = x));
    }

      public exportAsExcelFile(json: any[], excelFileName: string) {
        const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);
        const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
        const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
        this.saveAsExcelFile(excelBuffer, excelFileName);
      }

      private saveAsExcelFile(buffer: any, fileName: string) {
         const data: Blob = new Blob([buffer], {type: this.EXCEL_TYPE});
         FileSaver.saveAs(data, fileName + '_export_' + new  Date().getTime() + this.EXCEL_EXTENSION);
      }
    }


