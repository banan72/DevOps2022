import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Gameboard1Component } from './gameboard1.component';

describe('Gameboard1Component', () => {
  let component: Gameboard1Component;
  let fixture: ComponentFixture<Gameboard1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Gameboard1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Gameboard1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
