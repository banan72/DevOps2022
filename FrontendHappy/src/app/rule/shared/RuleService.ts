import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {RuleDto} from "./RuleDto";

@Injectable({
  providedIn: 'root'
})
export class RuleService {
  constructor(private _http:HttpClient) {
  }

  getAll():Observable<RuleDto[]>{
    return this._http.get<RuleDto[]>('https://localhost:5001/api/Rule')
  }
}
