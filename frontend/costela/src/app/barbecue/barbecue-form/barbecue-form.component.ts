import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup, FormBuilder } from '@angular/forms';
import { Barbecue } from '../models/barbecue.model';

@Component({
  selector: 'app-barbecue-form',
  templateUrl: './barbecue-form.component.html',
  styleUrls: ['./barbecue-form.component.less']
})
export class BarbecueFormComponent implements OnInit {

  data = [{
    name: 'Joao',
    value: '1'
  }, { name: 'Roberta', value: '2' }];

  barbecue: Barbecue = {
    date: new Date(),
    description: 'Contratação do João',
    totalAmount: 280,
    totalParticipants: 15
  };

  public savedAt = new Date();
  public barbecueForm: FormGroup;
  public _participants: Array<any> = [];

  constructor(private fb: FormBuilder) { }

  public ngOnInit() {
    this.barbecueForm = this.fb.group({
      title: [],
      participants: this.fb.array([this.fb.group({ participant: '' })])
    })
  }

  get participants() {
    return this.barbecueForm.get('participants') as FormArray;
  }

  public filterData() {
    return this.data.filter(o => !this._participants.includes(o));
  }

  public addParticipant(participant: any) {
    this._add(participant);
    this.participants.push(this.fb.group({ participant: '' }));
  }

  public removeParticipant(index) {
    this._remove(index);
    this.participants.removeAt(index);
    if (this._participants.length === 0) {
      this._clearFormArray(this.participants);
      this.participants.push(this.fb.group({ participant: '' }));
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

  whosgoing() {
    console.log(this._participants);
  }

}
