import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Pickedcardrow } from './pickedcardrow';

describe('Pickedcardrow', () => {
  let component: Pickedcardrow;
  let fixture: ComponentFixture<Pickedcardrow>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Pickedcardrow]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Pickedcardrow);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
