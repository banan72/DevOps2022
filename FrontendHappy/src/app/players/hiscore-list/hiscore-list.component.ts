import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../shared/players.service";
import {PlayerDto} from "../shared/player.dto";
import {RuleDto} from "../../rule/shared/RuleDto";
import {RuleService} from "../../rule/shared/RuleService";

@Component({
  selector: 'app-hiscore-list',
  templateUrl: './hiscore-list.component.html',
  styleUrls: ['./hiscore-list.component.css']
})
export class HiscoreListComponent implements OnInit {
   players: PlayerDto[] | undefined;
   rules: RuleDto[] | undefined;

  constructor(private _playerService: PlayersService, private _rulseService: RuleService) { }

  ngOnInit(): void {
    this._playerService.getTopX(3)
      .subscribe(players => {
        this.players = players;
      });
    this._rulseService.getAll().subscribe(rules => {this.rules = rules;})
  }

}
