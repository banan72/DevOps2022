import { NgModule } from '@angular/core';
import {Gameboard1Component} from "./gameboard/gameboard1/gameboard1.component";
import {Gameboard2Component} from "./gameboard/gameboard2/gameboard2.component";
import {CommonModule} from "@angular/common";



@NgModule({
  declarations: [
    Gameboard1Component,
    Gameboard2Component
  ],
  imports: [CommonModule]

})
export class AppRoutingModule { }
