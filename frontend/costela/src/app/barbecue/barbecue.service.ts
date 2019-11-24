import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Barbecue } from './models/barbecue.model';
import { Participant } from './models/participant.model';


@Injectable({ providedIn: 'root' })
export class BarbecueService {

    constructor(private _http: HttpClient) {

    }

    public getAllBarbecues(): Observable<Array<Barbecue>> {
        return this._http.get<Array<Barbecue>>('http://localhost:57331/trinca/api/v1/Barbecue');
    }

    public put(barbecue: Barbecue): Observable<Barbecue> {
        return this._http.put<Barbecue>(`http://localhost:57331/trinca/api/v1/Barbecue/${barbecue.id}`, barbecue);
    }

    public post(barbecue: Barbecue): Observable<Barbecue> {
        return this._http.post<Barbecue>('http://localhost:57331/trinca/api/v1/Barbecue', barbecue);
    }

    public addParticipant(barbecueId: string, participant: Participant) {
        return this._http.post<Participant>(`http://localhost:57331/trinca/api/v1/Barbecue/${barbecueId}/participants`, { participantId: participant.id, drinking: participant.drinking });
    }

    public removeParticipant(barbecueId: string, participantId: string, paid: boolean) {
        return this._http.delete<Participant>(`http://localhost:57331/trinca/api/v1/Barbecue/${barbecueId}/participants/${participantId}?wasPaid=${paid}`);
    }

    public changeDrinkingOption(barbecueId: string, presence: { participantId: any; drinking: any; paid: boolean }) {
        return this._http.put(`http://localhost:57331/trinca/api/v1/Barbecue/${barbecueId}/participants/${presence.participantId}`, presence)
    }

    public setPayment(barbecueId: string, participantId: string, paid: any) {
        return this._http.put(`http://localhost:57331/trinca/api/v1/Barbecue/${barbecueId}/participants/${participantId}/payment`, paid);
    }

    public getEligibleParticipants(): Observable<Array<Participant>> {
        return this._http.get<Array<Participant>>(`http://localhost:57331/trinca/api/v1/people`);
    }

    get(id: string): Observable<Barbecue> {
        return this._http.get<Barbecue>(`http://localhost:57331/trinca/api/v1/Barbecue/${id}`);
    }
}