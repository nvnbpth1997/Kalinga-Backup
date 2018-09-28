import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MindDetailsComponent } from './mind-details.component';

describe('MindDetailsComponent', () => {
  let component: MindDetailsComponent;
  let fixture: ComponentFixture<MindDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MindDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MindDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
