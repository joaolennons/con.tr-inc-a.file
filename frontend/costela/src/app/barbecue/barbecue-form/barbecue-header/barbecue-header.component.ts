import { Component, OnInit, Input } from '@angular/core';
import { Barbecue } from '../../models/barbecue.model';

@Component({
  selector: 'app-barbecue-header',
  templateUrl: './barbecue-header.component.html',
  styleUrls: ['./barbecue-header.component.less']
})
export class BarbecueHeaderComponent implements OnInit {

  @Input() barbecue: Barbecue;

  constructor() { }

  ngOnInit() {
  }

}
