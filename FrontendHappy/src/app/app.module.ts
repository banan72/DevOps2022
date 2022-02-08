import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import {Gameboard1Component} from "./gameboard/gameboard1/gameboard1.component";
import {Gameboard2Component} from "./gameboard/gameboard2/gameboard2.component";

@NgModule({
  declarations: [
    AppComponent,
    Gameboard1Component,
    Gameboard2Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
