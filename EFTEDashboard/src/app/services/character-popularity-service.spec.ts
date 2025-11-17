import { TestBed } from '@angular/core/testing';

import { CharacterPopularityService } from './character-popularity-service';

describe('CharacterPopularityService', () => {
  let service: CharacterPopularityService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CharacterPopularityService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
