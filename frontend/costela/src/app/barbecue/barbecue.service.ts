import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Barbecue } from "./models/barbecue.model";
import { Participant } from "./models/participant.model";
import { Api } from "../app-consts";

@Injectable({ providedIn: "root" })
export class BarbecueService {
  constructor(private _http: HttpClient) {}

  public getAll(): Observable<Array<Barbecue>> {
    return this._http.get<Array<Barbecue>>(Api.barbecue);
  }

  public get(id: string): Observable<Barbecue> {
    return this._http.get<Barbecue>(`${Api.barbecue}/${id}`);
  }

  public post(barbecue: Barbecue): Observable<Barbecue> {
    return this._http.post<Barbecue>(Api.barbecue, barbecue);
  }

  public put(barbecue: Barbecue): Observable<Barbecue> {
    return this._http.put<Barbecue>(`${Api.barbecue}/${barbecue.id}`, barbecue);
  }

  public delete(barbecueId: string): Observable<any> {
    return this._http.delete<Participant>(`${Api.barbecue}/${barbecueId}`);
  }

  public addParticipant(barbecueId: string, participant: Participant) {
    return this._http.post<Participant>(Api.participants(barbecueId), {
      participantId: participant.id,
      drinking: participant.drinking
    });
  }

  public removeParticipant(
    barbecueId: string,
    participantId: string,
    paid: boolean
  ) {
    return this._http.delete<Participant>(
      `${Api.participants(barbecueId)}/${participantId}?wasPaid=${paid}`
    );
  }

  public changeDrinkingOption(
    barbecueId: string,
    presence: { participantId: any; drinking: any; paid: boolean }
  ) {
    return this._http.put(
      `${Api.participants(barbecueId)}/${presence.participantId}`,
      presence
    );
  }

  public setPayment(barbecueId: string, participantId: string, paid: any) {
    return this._http.put(
      `${Api.participants(barbecueId)}/${participantId}/payment`,
      paid
    );
  }

  public getEligibleParticipants(): Observable<Array<Participant>> {
    return this._http.get<Array<Participant>>(Api.people);
  }
}
