import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {Gameboard1Component} from "./gameboard1/gameboard1.component";

const routes: Routes = [
  { path: 'gameboard1', component: Gameboard1Component}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class GameboardRoutingModule { }
