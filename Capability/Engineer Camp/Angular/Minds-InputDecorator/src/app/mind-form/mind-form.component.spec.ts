import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MindFormComponent } from './mind-form.component';

describe('MindFormComponent', () => {
  let component: MindFormComponent;
  let fixture: ComponentFixture<MindFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MindFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MindFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
