import { Injectable } from '@angular/core';
import {Minds} from '../shared/minds';
import{Http, Response, Headers, RequestOptions, RequestMethod} from '@angular/http';
import { Observable, pipe } from 'rxjs';
import { map } from "rxjs/operators";
import {NgModule} from'@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from "rxjs/internal/operators";
import Swal from 'sweetalert2';
import { Settings } from "src/app/shared/settings";
import * as FileSaver from 'file-saver';
import * as XLSX from 'xlsx';  
import { Exportfile } from "src/app/shared/exportfile"; 
 


@Injectable({
  providedIn: "root"
})
export class MindsService {
  readonly url = "http://localhost:64483/";
//  readonly url = "https://amsapijun18dotnet.azurewebsites.net/";
  mindsList: Minds[];
  EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
  EXCEL_EXTENSION = '.xlsx';
  excelFileName : string;
  settingsdetails: Settings;
  constructor(private http: Http, private httpclient: HttpClient) {}
  public exportAsExcelFile(data: Exportfile[], nameref: number): void {
    if(nameref == 1)
      this.excelFileName='Last Three Days';
    else if(nameref == 2)
      this.excelFileName='Last Week';
    else if(nameref == 3)
      this.excelFileName='Last Three Months';
    else if(nameref == 4)
      this.excelFileName='Threshold';
    else if(nameref == 5)
      this.excelFileName='Last Month';
    else
      this.excelFileName='Last Three Days';
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(data);
    const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
    const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
    this.saveAsExcelFile(excelBuffer, this.excelFileName);
  }
  private saveAsExcelFile(buffer: any, fileName: string): void {
     const data: Blob = new Blob([buffer], {type: this.EXCEL_TYPE});
     FileSaver.saveAs(data, fileName + this.EXCEL_EXTENSION);
  }
  getOnTimeList() {
    return this.httpclient
      .get(this.url + "api/MindsDb/GetOnTimeSwipes")
      .subscribe((x: Minds[]) => {
        (this.mindsList = x), console.log(this.mindsList);
      });
  }
  getLateSwipe() {
    return this.http
      .get(this.url + "api/MindsDb/GetLateSwipes")
      .pipe(
        map((data: Response) => {
          return data.json() as Minds[];
        })
      )
      .subscribe(x => (this.mindsList = x));
  }
  getNotSwipe() {
    return this.http
      .get(this.url + "api/MindsDb/GetNotSwipes")
      .pipe(
        map((data: Response) => {
          return data.json() as Minds[];
        })
      )
      .subscribe(x => (this.mindsList = x));
  }

  postFile(fileToUpload: File) {
    const endpoint = this.url + "api/MindsDb/ExcelBindings";
    const formData: FormData = new FormData();
    formData.append("FileTo", fileToUpload, fileToUpload.name);
    return this.httpclient.post(endpoint, formData);
  }
  getRepeatDefaulters() {
    return this.http
      .get(this.url + "api/MindsDb/GetRepeatDefaulters")
      .pipe(
        map((data: Response) => {
          return data.json() as Minds[];
        })
      )
      .subscribe(x => (this.mindsList = x));
  }
  getMind(Mid: string) {
    return this.http.get(this.url + "api/MindsDb/GetMind/" + Mid).pipe(
      map((data: Response) => {
        return data.json() as Minds;
      })
    );
  }
  getFilteredRepeatedDefaulters(value: string)
  {
    if(value == '1') {
      return this.httpclient
        .get(this.url + "api/MindsDb/GetLastWeekRepeatedDefaulters")
        .subscribe((x: Minds[]) => (this.mindsList = x));
    }
    else if(value == '2')
      {
      return this.httpclient.get(this.url+"api/MindsDb/GetLastMonthRepeatedDefaulters").subscribe((x:Minds[])=>(this.mindsList = x));
      }
    else if(value == '3')
      {
      return this.httpclient.get(this.url+"api/MindsDb/GetLastThreeMonthsRepeatedDefaulters").subscribe((x:Minds[])=>(this.mindsList = x));
      }
      else
        {
     return this.http
       .get(this.url + "api/MindsDb/GetRepeatDefaulters")
       .pipe(map((data: Response) => {
           return data.json() as Minds[];
         }))
       .subscribe(x => (this.mindsList = x));
        }
    }
  onUpload(resArr: any) {
    return this.http
      .post(this.url + "api/MindsDb/PostMindDetails", resArr)
  }
  postSettings(set: Settings)
  {
     return this.httpclient.post(this.url +"api/MindsDb/PostSettings",set).subscribe();
  }
  getSettings(get: string)
  {
    return this.httpclient.get(this.url + "api/MindsDb/GetSettings/"+get).subscribe((x:Settings) => this.settingsdetails = x);
  }
  getFilteredDefaulters(value: string)
  {
    if(value == '1') {
      return this.httpclient
        .get(this.url + "api/MindsDb/GetLastThreeDaysDefaulters")
        .subscribe((x: Minds[]) => (this.mindsList = x));
    }
    else if(value == '2')
      {
      return this.httpclient.get(this.url+"api/MindsDb/GetLastWeekDefaulters").subscribe((x:Minds[])=>(this.mindsList = x));
      }
    else if(value == '3')
      {
      return this.httpclient.get(this.url+"api/MindsDb/GetLastThreeMonthsDefaulters").subscribe((x:Minds[])=>(this.mindsList = x));
      }
      else if(value == '4')
        {
          return this.httpclient.get(this.url+"api/MindsDb/GetThresholdDefaulters").subscribe((x:Minds[])=>(this.mindsList) = x);
        }
      else if(value == '5')
        {
          return this.httpclient.get(this.url+"api/MindsDb/GetLastMonthDefaulters").subscribe((x:Minds[])=>(this.mindsList = x));
        }
      else
        {
     return this.http
       .get(this.url + "api/MindsDb/GetLastThreeDaysDefaulters")
       .pipe(map((data: Response) => {
           return data.json() as Minds[];
         }))
       .subscribe(x => (this.mindsList = x));
        }
    }

  onExcuseUpload(resArr: any){
    return this.http
    .post(this.url + "api/MindsDb/PostExcusedMindsDetails", resArr)
  }

  OnCMUpload(resArrcm:any)
  {
  return this.http.post(this.url + "api/MindsDb/PostCMDetails", resArrcm)
  } 

  postImage(formData: FormData) {
    return this.http.put(this.url + 'api/MindsDb/UploadImages', formData);
  }
}
