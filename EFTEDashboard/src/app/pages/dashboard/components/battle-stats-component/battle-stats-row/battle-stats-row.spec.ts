import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BattleStatsRow } from './battle-stats-row';

describe('BattleStatsRow', () => {
  let component: BattleStatsRow;
  let fixture: ComponentFixture<BattleStatsRow>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BattleStatsRow]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BattleStatsRow);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
