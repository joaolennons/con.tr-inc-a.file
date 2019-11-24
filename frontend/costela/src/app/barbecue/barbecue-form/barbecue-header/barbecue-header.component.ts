import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Barbecue } from '../../models/barbecue.model';

@Component({
  selector: 'app-barbecue-header',
  templateUrl: './barbecue-header.component.html',
  styleUrls: ['./barbecue-header.component.less']
})
export class BarbecueHeaderComponent implements OnInit {

  @Input() barbecue: Barbecue;
  @Output() change = new EventEmitter<any>();
  public description: string;
  public date: string;

  constructor() { }

  ngOnInit() {
  }

  setDate() {
    this.barbecue.date = new Date(this.date);
    this.change.emit(this.barbecue);
  }

  setDescription() {
    this.barbecue.description = this.description;
    this.change.emit(this.barbecue);
  }
}
