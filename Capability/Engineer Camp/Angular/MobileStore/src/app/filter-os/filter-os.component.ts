import { Component, OnInit } from '@angular/core';
import { IMobile } from '../IMobile';
import { Pipe, PipeTransform } from '@angular/core';

@Component({
  selector: 'app-filter-os',
  templateUrl: './filter-os.component.html',
  styleUrls: ['./filter-os.component.css']
})

@Pipe({ name: 'filter' })
export class FilterOSComponent implements PipeTransform {
  transform(allMobiles: IMobile[]) {
    return allMobiles.filter(mobile => mobile.os);
  }
}
