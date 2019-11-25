import { Component, OnInit, ViewEncapsulation } from "@angular/core";
import { Router } from "@angular/router";
import { BarbecueService } from "../barbecue.service";
import { Barbecue } from "../models/barbecue.model";
import { PoTableColumn, PoTableAction } from "@portinari/portinari-ui";
import { Literals } from "./localization/barbecue-list-pt-br";
import { Columns, BbqFormRoute } from "./barbecue-list.conts";

@Component({
  selector: "app-barbecue-list",
  templateUrl: "./barbecue-list.component.html",
  styleUrls: ["./barbecue-list.component.less"],
  encapsulation: ViewEncapsulation.None
})
export class BarbecueListComponent implements OnInit {
  public readonly literals = Literals;
  public readonly columns: Array<PoTableColumn> = Columns;
  public readonly actions: Array<PoTableAction> = [
    { action: this.goToBbqForm.bind(this), label: this.literals.details }
  ];

  public events: Array<Barbecue>;

  constructor(public router: Router, private _service: BarbecueService) {}

  ngOnInit() {
    this._service.getAll().subscribe(
      bbqs => (this.events = bbqs),
      ex => console.error(ex)
    );
  }

  public goToBbqForm(bbq) {
    this.router.navigate([BbqFormRoute, bbq ? bbq.id : ""]);
  }
}
