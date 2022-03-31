import { Component, OnInit } from '@angular/core';
import {Game} from "../game";

import {newArray} from "@angular/compiler/src/util";
import {PlayerModel} from "../player.model";
import {RuleService} from "../../rule/shared/RuleService";
import {RuleDto} from "../../rule/shared/RuleDto";

@Component({
  selector: 'app-gameboard1',
  templateUrl: './gameboard1.component.html',
  styleUrls: ['./gameboard1.component.css']
})
export class Gameboard1Component implements OnInit {

  rules: RuleDto[] = []

  constructor(private _ruleService: RuleService ) {


  }

  ngOnInit(): void {
    this._ruleService.getAll()
      .subscribe(rules => {
        this.rules = rules;
        this.rules.push({id : 0, ruleName :"test rule", category : ""} as RuleDto)
        console.log(this.rules.length)
        let game = new Game(this.rules)
        game.Draw()

        const b = document.getElementById('btnNextPlayer') as HTMLButtonElement
        b.addEventListener('click', (e:Event) => this.nextPlayer(game));

        const rollbtn = document.getElementById("btnRoll") as HTMLButtonElement
        rollbtn.addEventListener('click', (e:Event) => this.roll(game));

        const e = document.getElementById('lblCurrentPlayer') as HTMLLabelElement;
        e.innerHTML = "Current Player " + game.setPlayers_fromModel(players)
      });


    //TODO let users put their own name
    let players = this.mockPlayers();


    const c = document.getElementById('btnNextPlayer') as HTMLButtonElement;
    c.disabled = true



  }

  private mockPlayers() {
    let player1 = new class implements PlayerModel {
      id: number = 1;
      name: string = "Bob";
    }
    let player2 = new class implements PlayerModel {
      id: number = 2;
      name: string = "Kurt";
    }
    let player3 = new class implements PlayerModel {
      id: number = 3;
      name: string = "John";
    }
    let player4 = new class implements PlayerModel {
      id: number = 4;
      name: string = "Grethe";
    }
    return [player1, player2, player3, player4]
  }

  nextPlayer(game:Game) {
    let Player = game.nextPlayer()

    this.switchDisabledButton();
    const e = document.getElementById('lblCurrentPlayer') as HTMLLabelElement;
    e.innerHTML = "Current Player: " + Player
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

  roll(game: Game) {
    let dieRoll  = game.roll()
    const e = document.getElementById('lblDiceRolled') as HTMLLabelElement;
    e.innerHTML = "you rolled a " + dieRoll

    const l = document.getElementById('lblRule') as HTMLLabelElement;
    l.innerHTML = "Rule: " + game.move(dieRoll)

    this.switchDisabledButton()
    }
}
