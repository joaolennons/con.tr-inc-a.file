import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup, FormBuilder } from '@angular/forms';
import { Barbecue } from '../models/barbecue.model';
import { BarbecueService } from '../barbecue.service';
import { ActivatedRoute } from '@angular/router';
import { Participant } from '../models/participant.model';

@Component({
  selector: 'app-barbecue-form',
  templateUrl: './barbecue-form.component.html',
  styleUrls: ['./barbecue-form.component.less']
})
export class BarbecueFormComponent implements OnInit {

  public readonly: boolean;
  public data: Array<Participant>;
  public barbecue: Barbecue = new Barbecue();

  public savedAt = new Date();
  public barbecueForm: FormGroup;
  public _participants: Array<any> = [];

  constructor(private service: BarbecueService, private fb: FormBuilder, private activatedRoute: ActivatedRoute) { }

  public ngOnInit() {
    const id = this.activatedRoute.snapshot.params.id;

    if (id) {
      this.readonly = true;
      this.getBarbecue(id);
    }

    this.service.getEligibleParticipants()
      .subscribe(people => this.data = people, error => console.error(error));

    this.barbecueForm = this.fb.group({
      title: [],
      participants: this.fb.array([this.fb.group({ participant: '' })])
    })
  }

  public getBarbecue(id: string) {
    this.service.get(id)
      .subscribe(bbq => {
        this.barbecue = bbq;
        if (this.readonly) {
          this._participants = [];
          this._clearFormArray(this.participants);
          bbq.participants.forEach(o => {
            this._add(o);
            this.participants.push(this.fb.group({ participant: '' }));
          });
          this.participants.push(this.fb.group({ participant: '' }));
        }
      }, error => console.error(error));
  }

  public editBarbecue(barbecue: Barbecue) {
    if (!this.barbecue.id) {
      this.service.post(this.barbecue).subscribe(bbq => {
        this.barbecue = bbq;
      }, error => console.error(error));
    } else {
      this.service.put(barbecue).subscribe(bbq => {
        this.barbecue = bbq;
      }, error => console.error(error));
    }
  }

  get participants() {
    return this.barbecueForm.get('participants') as FormArray;
  }

  public filterData() {
    return this.data ? this.data.filter(o => !this._participants.find(w => w.id === o.id)) : [];
  }

  public addParticipant(participant: any) {
    if (this.readonly) return;
    this.service.addParticipant(this.barbecue.id, participant)
      .subscribe(() => {
        this._add(participant);
        this.participants.push(this.fb.group({ participant: '' }));
        this.getBarbecue(this.barbecue.id);
      }, error => console.error(error));
  }

  public removeParticipant(index) {
    if (this.exists(index)) {
      this.service.removeParticipant(this.barbecue.id, this._participants[index].id)
        .subscribe(() => {
          this._remove(index);
          this.participants.removeAt(index);

          if (this._participants.length === 0) {
            this._clearFormArray(this.participants);
            this.participants.push(this.fb.group({ participant: '' }));
          }

          this.getBarbecue(this.barbecue.id);

        }, error => console.error(error));
    }
  }

  public changeDrinkingOption(item) {
    const participant = this._participants[item];
    this.service.changeDrinkingOption(this.barbecue.id, { participantId: participant.id, drinking: !(participant.value === 20) })
      .subscribe(() => {
        this.getBarbecue(this.barbecue.id);
      }, error => console.error(error))
  }

  public setPayment(paid, index) {
    const participant = this._participants[index];
    this.service.setPayment(this.barbecue.id, participant.id, { paid: paid })
      .subscribe(() => {
        this.getBarbecue(this.barbecue.id);
      }, error => console.error(error))
  }

  private _add(participant: any) {
    this._participants.push(participant);
  }

  private _remove(participant: number) {
    this._participants.splice(participant, 1);
  }


  private _clearFormArray = (formArray: FormArray) => {
    while (formArray.length !== 0) {
      formArray.removeAt(0)
    }
  }

  public exists(index) {
    return this._participants[index];
  }

  public enableEditing() {
    console.log(this._participants);
    this.readonly = false;
  }

}
