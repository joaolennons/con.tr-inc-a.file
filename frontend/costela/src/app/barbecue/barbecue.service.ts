import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({ providedIn: 'root' })
export class BarbecueService {

    constructor(private _http: HttpClient) {

    }

    public getAllBarbecues(): Observable<any> {
        return this._http.get('http://localhost:57331/trinca/api/v1/Barbecue');
    }
}