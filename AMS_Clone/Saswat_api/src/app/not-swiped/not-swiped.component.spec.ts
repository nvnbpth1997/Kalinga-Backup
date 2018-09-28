import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotSwipedComponent } from './not-swiped.component';

describe('NotSwipedComponent', () => {
  let component: NotSwipedComponent;
  let fixture: ComponentFixture<NotSwipedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotSwipedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotSwipedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
