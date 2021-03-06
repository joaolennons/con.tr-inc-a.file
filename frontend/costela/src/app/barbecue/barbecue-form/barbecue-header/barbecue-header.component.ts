import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  ViewEncapsulation
} from "@angular/core";
import { Barbecue } from "../../models/barbecue.model";

@Component({
  selector: "app-barbecue-header",
  templateUrl: "./barbecue-header.component.html",
  styleUrls: ["./barbecue-header.component.less"],
  encapsulation: ViewEncapsulation.None
})
export class BarbecueHeaderComponent {
  @Input() barbecue: Barbecue;
  @Output() change = new EventEmitter<any>();
  public description: string;
  public date: Date;
  public today = new Date();

  constructor() {}

  setDate() {
    if (this.date) {
      this.barbecue.date = new Date(this.date);
      this.change.emit(this.barbecue);
    }
  }

  setDescription() {
    this.barbecue.description = this.description;
    this.change.emit(this.barbecue);
  }
}
