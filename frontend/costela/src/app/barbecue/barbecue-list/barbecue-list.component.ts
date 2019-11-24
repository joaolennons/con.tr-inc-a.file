import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BarbecueService } from '../barbecue.service';
import { Barbecue } from '../models/barbecue.model';

@Component({
  selector: 'app-barbecue-list',
  templateUrl: './barbecue-list.component.html',
  styleUrls: ['./barbecue-list.component.less']
})
export class BarbecueListComponent implements OnInit {

  public events: Array<Barbecue>;
  constructor(public router: Router, private _service: BarbecueService) { }

  ngOnInit() {
    this._service.getAllBarbecues()
      .subscribe(bbqs => this.events = bbqs, ex => console.error(ex));
  }

  public goToNewBbq() {
    this.router.navigateByUrl('new-bbq');
  }
}
