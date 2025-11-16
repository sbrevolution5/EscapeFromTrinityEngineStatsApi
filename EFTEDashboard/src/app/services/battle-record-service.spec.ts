import { TestBed } from '@angular/core/testing';

import { BattleRecordService } from './battle-record-service';

describe('BattleRecordService', () => {
  let service: BattleRecordService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BattleRecordService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
