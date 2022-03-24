import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HiscoreListComponent} from "./hiscore-list/hiscore-list.component";

const routes: Routes = [
  {path: '', component:  HiscoreListComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlayersRoutingModule { }
