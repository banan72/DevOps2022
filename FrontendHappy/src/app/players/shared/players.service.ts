import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {PlayerDto} from "./player.dto";

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  constructor(private _http: HttpClient) {
  }

  getAll(): Observable<PlayerDto[]>{
    return this._http.get<PlayerDto[]>('https://localhost:5001/api/Player');
  }
  getTopX(id: number): Observable<PlayerDto[]>{
    return this._http.get<PlayerDto[]>(`https://localhost:5001/api/Player/GetTopSippers?topPlayers=${id}`);
  }
}
