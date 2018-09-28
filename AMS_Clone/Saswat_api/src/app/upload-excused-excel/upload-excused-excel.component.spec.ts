import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadExcusedExcelComponent } from './upload-excused-excel.component';

describe('UploadExcusedExcelComponent', () => {
  let component: UploadExcusedExcelComponent;
  let fixture: ComponentFixture<UploadExcusedExcelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UploadExcusedExcelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UploadExcusedExcelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
