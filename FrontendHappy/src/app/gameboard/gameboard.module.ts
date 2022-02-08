import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Gameboard1Component } from './gameboard1/gameboard1.component';
import { Gameboard2Component } from './gameboard2/gameboard2.component';
import { GameboardRoutingModule } from './gameboard-routing.module';



@NgModule({
  declarations: [
    Gameboard1Component,
    Gameboard2Component
  ],
  imports: [
    CommonModule,
    GameboardRoutingModule
  ]
})
export class GameboardModule { }
