import { Component, OnInit } from '@angular/core';
import {PlayersService} from "../shared/players.service";
import {PlayerDto} from "../shared/player.dto";

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
      });
  }

}
