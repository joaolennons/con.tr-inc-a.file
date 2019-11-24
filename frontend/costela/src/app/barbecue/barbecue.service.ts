import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Barbecue } from './models/barbecue.model';


@Injectable({ providedIn: 'root' })
export class BarbecueService {

    constructor(private _http: HttpClient) {

    }

    public getAllBarbecues(): Observable<Array<Barbecue>> {
        return this._http.get<Array<Barbecue>>('http://localhost:57331/trinca/api/v1/Barbecue');
    }

    public put(barbecue: Barbecue): Observable<Barbecue> {
        return this._http.put<Barbecue>('http://localhost:57331/trinca/api/v1/Barbecue', barbecue);
    }

    public post(barbecue: Barbecue): Observable<Barbecue> {
        return this._http.post<Barbecue>('http://localhost:57331/trinca/api/v1/Barbecue', barbecue);
    }
}