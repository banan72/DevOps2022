import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Gameboard2Component } from './gameboard2.component';

describe('Gameboard2Component', () => {
  let component: Gameboard2Component;
  let fixture: ComponentFixture<Gameboard2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Gameboard2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Gameboard2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
