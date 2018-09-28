import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterOSComponent } from './filter-os.component';

describe('FilterOSComponent', () => {
  let component: FilterOSComponent;
  let fixture: ComponentFixture<FilterOSComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilterOSComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilterOSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
