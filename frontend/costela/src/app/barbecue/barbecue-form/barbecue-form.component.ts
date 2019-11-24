import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup, FormBuilder } from '@angular/forms';
import { Barbecue } from '../models/barbecue.model';
import { BarbecueService } from '../barbecue.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-barbecue-form',
  templateUrl: './barbecue-form.component.html',
  styleUrls: ['./barbecue-form.component.less']
})
export class BarbecueFormComponent implements OnInit {

  data = [{
    name: 'Joao',
    participantId: 'a8b4dd13-25f1-45cc-af77-84e1bd92cb47'
  }, { name: 'Roberta', participantId: '985fed44-1254-41b4-876e-e0717504bfd8' }];

  barbecue: Barbecue = new Barbecue();

  public savedAt = new Date();
  public barbecueForm: FormGroup;
  public _participants: Array<any> = [];

  constructor(private service: BarbecueService, private fb: FormBuilder, private activatedRoute: ActivatedRoute) { }

  public ngOnInit() {
    const id = this.activatedRoute.snapshot.params.id;

    this.barbecueForm = this.fb.group({
      title: [],
      participants: this.fb.array([this.fb.group({ participant: '' })])
    })
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
    return this.data.filter(o => !this._participants.includes(o));
  }

  public addParticipant(participant: any) {
    this.service.addParticipant(this.barbecue.id, participant)
      .subscribe(() => {
        this._add(participant);
        this.participants.push(this.fb.group({ participant: '' }));
      }, error => console.error(error));
  }

  public removeParticipant(index) {
    if (this.exists(index)) {
      this.service.removeParticipant(this.barbecue.id, this._participants[index].participantId)
        .subscribe(() => {
          this._remove(index);
          this.participants.removeAt(index);
          if (this._participants.length === 0) {
            this._clearFormArray(this.participants);
            this.participants.push(this.fb.group({ participant: '' }));
          }
        }, error => console.error(error));
    }
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

  whosgoing() {
    console.log(this._participants);
  }

}
