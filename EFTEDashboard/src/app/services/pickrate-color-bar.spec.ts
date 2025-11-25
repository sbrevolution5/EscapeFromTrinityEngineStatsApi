import { TestBed } from '@angular/core/testing';

import { PickrateColorBar } from './pickrate-color-bar';

describe('PickrateColorBar', () => {
  let service: PickrateColorBar;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PickrateColorBar);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
