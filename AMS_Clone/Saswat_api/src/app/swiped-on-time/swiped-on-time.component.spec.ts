import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SwipedOnTimeComponent } from './swiped-on-time.component';

describe('SwipedOnTimeComponent', () => {
  let component: SwipedOnTimeComponent;
  let fixture: ComponentFixture<SwipedOnTimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SwipedOnTimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SwipedOnTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
