import { TestBed } from '@angular/core/testing';

import { PickRateService } from './pick-rate-service';

describe('PickRateService', () => {
  let service: PickRateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PickRateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
