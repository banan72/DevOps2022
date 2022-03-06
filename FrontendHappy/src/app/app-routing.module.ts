import { NgModule } from '@angular/core';
import {Gameboard1Component} from "./gameboard/gameboard1/gameboard1.component";
import {Gameboard2Component} from "./gameboard/gameboard2/gameboard2.component";
import {CommonModule} from "@angular/common";
import {RouterModule, Routes} from "@angular/router";
import {LoginComponent} from "./login/login.component";

const routes: Routes = [
  {path:'', component:LoginComponent},
  {path:'game', loadChildren: () => import('./gameboard/gameboard.module').then(m => m.GameboardModule)},
  {path:'players', loadChildren: () => import('./players/players.module').then(f => f.PlayersModule)}
];

@NgModule({
  declarations: [
    //Gameboard1Component,
    //Gameboard2Component
  ],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]

})
export class AppRoutingModule { }
