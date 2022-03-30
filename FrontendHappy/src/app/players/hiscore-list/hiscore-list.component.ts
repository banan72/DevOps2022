import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../shared/players.service";
import {PlayerDto} from "../shared/player.dto";
import {RuleDto} from "../../rule/shared/RuleDto";

@Component({
  selector: 'app-hiscore-list',
  templateUrl: './hiscore-list.component.html',
  styleUrls: ['./hiscore-list.component.css']
})
export class HiscoreListComponent implements OnInit {
   players: PlayerDto[] | undefined;

  constructor(private _playerService: PlayersService) { }

  ngOnInit(): void {
    this._playerService.getTopX(3)
      .subscribe(players => {
        this.players = players;
        this.players.push({id:0, name: "John", isAdmin : false, totalSips :40} as PlayerDto)
      });
  }

}
