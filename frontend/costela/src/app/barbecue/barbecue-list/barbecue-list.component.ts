import { Component, OnInit, ViewEncapsulation } from "@angular/core";
import { Router } from "@angular/router";
import { BarbecueService } from "../barbecue.service";
import { Barbecue } from "../models/barbecue.model";
import { PoTableColumn, PoTableAction } from "@portinari/portinari-ui";

@Component({
  selector: "app-barbecue-list",
  templateUrl: "./barbecue-list.component.html",
  styleUrls: ["./barbecue-list.component.less"],
  encapsulation: ViewEncapsulation.None
})
export class BarbecueListComponent implements OnInit {
  public events: Array<Barbecue>;
  constructor(public router: Router, private _service: BarbecueService) {}

  ngOnInit() {
    this._service.getAllBarbecues().subscribe(
      bbqs => (this.events = bbqs),
      ex => console.error(ex)
    );
  }

  public goToNewBbq(bbq) {
    this.router.navigate(["new-bbq", bbq ? bbq.id : ""]);
  }

  public readonly columns: Array<PoTableColumn> = [
    { property: "date", label: "Quando?", type: "date" },
    { property: "description", label: "A troco de quê?" },
    { property: "totalParticipants", label: "Quantos vão?" },
    {
      property: "totalAmount",
      label: "Valor a ser arrecadado",
      type: "currency",
      format: "BRL"
    },
    {
      property: "totalRaised",
      label: "Quanto já foi pago?",
      type: "currency",
      format: "BRL"
    }
  ];

  public readonly actions: Array<PoTableAction> = [
    { action: this.goToNewBbq.bind(this), label: "Detalhes do churras" }
  ];
}
