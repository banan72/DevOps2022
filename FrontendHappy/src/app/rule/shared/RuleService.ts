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
    console.log("GetAll")
    return this._http.get<RuleDto[]>('http://185.51.76.42:8091/api/Rule')
  }
}
