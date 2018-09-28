import { Image } from './../image';
import { FilterService } from './../filter.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-dash2',
  templateUrl: './dash2.component.html',
  styleUrls: ['./dash2.component.css']
})
export class Dash2Component implements OnInit {
  imageUrl: string;
  fileToUpload: File = null;

  imageToShow: any;
  uploadStatus = true;

  myFiles: File[] = [];

  constructor(private filterService: FilterService) { }

  ngOnInit() {
    // this.getImageFromService();
  }

  // handleFileInput(file: FileList)
  // {
  //   this.fileToUpload = file.item(0);
  //   const reader = new FileReader();
  //   reader.onload = (event: any) => {
  //     this.imageUrl = event.target.result;
  //   }
  //   reader.readAsDataURL(this.fileToUpload);
  // }

  getFileDetails (e) {
    console.log (e);
    for (let i = 0; i < e.length; i++) {
      this.myFiles.push(e[i]);
    }
  }

  uploadFiles () {
    const frmData = new FormData();
    for (let i = 0; i < this.myFiles.length; i++) {
        console.log (this.myFiles[i]);
        frmData.append('Image', this.myFiles[i], this.myFiles[i].name);
      }
      this.filterService.postFile(frmData).subscribe(data => {
        console.log('done');
  });
    for (let i = 0; i < this.myFiles.length; i++) {
      this.myFiles.pop();
    }
  }

// OnSubmit(Image)
// {
//   this.filterService.postFile(this.fileToUpload).subscribe(data =>
//   {
//     console.log('done');
//     Image.value = null;
//     // this.imageUrl = "/assets/img/upload.png";
//   })
// }

//  getImageFromService() {
//      this.isImageLoading = true;
//      this.filterService.getImage();
//     //    this.imageToShow = data;
//      this.isImageLoading = false;
//     //  }, error => {
//     //    this.isImageLoading = false;
//     //    console.log(error);
//     //  });
//  }

}
