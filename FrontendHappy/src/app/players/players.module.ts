import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlayersRoutingModule } from './players-routing.module';
import { HiscoreListComponent } from './hiscore-list/hiscore-list.component';
import {HttpClientModule} from "@angular/common/http";


@NgModule({
  declarations: [
    HiscoreListComponent
  ],
  imports: [
    CommonModule,
    PlayersRoutingModule,
  ]
})
export class PlayersModule { }
