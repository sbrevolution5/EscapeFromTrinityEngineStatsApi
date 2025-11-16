import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacterPopularityComponent } from './character-popularity-component';

describe('CharacterPopularityComponent', () => {
  let component: CharacterPopularityComponent;
  let fixture: ComponentFixture<CharacterPopularityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CharacterPopularityComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharacterPopularityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
