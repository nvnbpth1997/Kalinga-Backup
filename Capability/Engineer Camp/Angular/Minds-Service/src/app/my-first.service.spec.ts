import { TestBed, inject } from '@angular/core/testing';

import { MyFirstService } from './my-first.service';

describe('MyFirstService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MyFirstService]
    });
  });

  it('should be created', inject([MyFirstService], (service: MyFirstService) => {
    expect(service).toBeTruthy();
  }));
});
