import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PassiveStats } from './passive-stats';

describe('PassiveStats', () => {
  let component: PassiveStats;
  let fixture: ComponentFixture<PassiveStats>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PassiveStats]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PassiveStats);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
