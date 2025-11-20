import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleGame } from './single-game';

describe('SingleGame', () => {
  let component: SingleGame;
  let fixture: ComponentFixture<SingleGame>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SingleGame]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SingleGame);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
