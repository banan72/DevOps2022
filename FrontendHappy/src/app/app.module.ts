import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import {Gameboard1Component} from "./gameboard/gameboard1/gameboard1.component";
import {Gameboard2Component} from "./gameboard/gameboard2/gameboard2.component";
import {RouterModule} from "@angular/router";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatToolbarModule} from '@angular/material/toolbar';

@NgModule({
  declarations: [
    AppComponent,
    Gameboard1Component,
    Gameboard2Component,
    LoginComponent
  ],
    imports: [
      BrowserModule,
      AppRoutingModule,
      RouterModule,
      BrowserAnimationsModule,
      FlexLayoutModule,
      MatFormFieldModule,
      MatInputModule,
      MatButtonModule,
      MatCardModule,
      MatToolbarModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
