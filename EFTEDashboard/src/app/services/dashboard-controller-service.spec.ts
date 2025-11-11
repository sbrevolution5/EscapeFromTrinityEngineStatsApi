import { TestBed } from '@angular/core/testing';

import { DashboardControllerService } from './dashboard-controller-service';

describe('DashboardControllerService', () => {
  let service: DashboardControllerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DashboardControllerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
