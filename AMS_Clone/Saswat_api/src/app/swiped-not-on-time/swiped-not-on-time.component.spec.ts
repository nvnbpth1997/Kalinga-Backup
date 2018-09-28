import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SwipedNotOnTimeComponent } from './swiped-not-on-time.component';

describe('SwipedNotOnTimeComponent', () => {
  let component: SwipedNotOnTimeComponent;
  let fixture: ComponentFixture<SwipedNotOnTimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SwipedNotOnTimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SwipedNotOnTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
