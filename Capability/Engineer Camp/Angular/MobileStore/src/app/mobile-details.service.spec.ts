import { TestBed, inject } from '@angular/core/testing';

import { MobileDetailsService } from './mobile-details.service';

describe('MobileDetailsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MobileDetailsService]
    });
  });

  it('should be created', inject([MobileDetailsService], (service: MobileDetailsService) => {
    expect(service).toBeTruthy();
  }));
});
