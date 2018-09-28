import { TestBed, inject } from '@angular/core/testing';

import { MindsService } from './minds.service';

describe('MindsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MindsService]
    });
  });

  it('should be created', inject([MindsService], (service: MindsService) => {
    expect(service).toBeTruthy();
  }));
});
