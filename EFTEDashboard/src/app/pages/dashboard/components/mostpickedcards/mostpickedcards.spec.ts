import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Mostpickedcards } from './mostpickedcards';

describe('Mostpickedcards', () => {
  let component: Mostpickedcards;
  let fixture: ComponentFixture<Mostpickedcards>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Mostpickedcards]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Mostpickedcards);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
