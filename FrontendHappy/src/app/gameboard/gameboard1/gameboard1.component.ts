import { Component, OnInit } from '@angular/core';
import {Game} from "../game";

@Component({
  selector: 'app-gameboard1',
  templateUrl: './gameboard1.component.html',
  styleUrls: ['./gameboard1.component.css']
})
export class Gameboard1Component implements OnInit {

  constructor() { }

  ngOnInit(): void {
    new Game().Draw()
  }

}
