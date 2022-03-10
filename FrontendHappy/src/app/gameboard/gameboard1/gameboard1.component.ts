import { Component, OnInit } from '@angular/core';
import {Game} from "../game";

@Component({
  selector: 'app-gameboard1',
  templateUrl: './gameboard1.component.html',
  styleUrls: ['./gameboard1.component.css']
})
export class Gameboard1Component implements OnInit {

  game:Game = new Game()


  constructor() { }

  ngOnInit(): void {
    this.game.Draw()
    this.game.setPlayers(4)

    const c = document.getElementById('btnNextPlayer') as HTMLButtonElement;
    c.disabled = true
    const e = document.getElementById('lblCurrentPlayer') as HTMLLabelElement;
    e.innerHTML = "Current Player " + 1

  }

  nextPlayer() {
    let nextPlayer = this.game.nextPlayer()

    this.switchDisabledButton();

    const e = document.getElementById('lblCurrentPlayer') as HTMLLabelElement;
    e.innerHTML = "Current Player " + (nextPlayer +1)
  }

  private switchDisabledButton() {
    const b = document.getElementById('btnRoll') as HTMLButtonElement;
    const c = document.getElementById('btnNextPlayer') as HTMLButtonElement;

    if(b.disabled){
      b.disabled = false
      c.disabled = true
    }
    else {
      b.disabled = true
      c.disabled = false
    }

  }

  roll() {
    let dieRoll  = this.game.roll()
    const e = document.getElementById('lblDiceRolled') as HTMLLabelElement;
    e.innerHTML = "you rolled a " + dieRoll
    this.game.move(dieRoll)

    this.switchDisabledButton()
    }
}
