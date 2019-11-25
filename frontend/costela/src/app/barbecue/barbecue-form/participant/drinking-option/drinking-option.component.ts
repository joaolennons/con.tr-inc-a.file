import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Literals } from "./localization/drinking-option-pt-br";

@Component({
  selector: "app-drinking-option",
  templateUrl: "./drinking-option.component.html",
  styleUrls: ["./drinking-option.component.less"]
})
export class DrinkingOptionComponent implements OnInit {
  @Input() off: number;
  @Input() on: number;
  @Input() readonly: boolean;
  @Output() change = new EventEmitter<any>();
  @Input() selected: boolean;
  public readonly literals = Literals;

  constructor() {}

  ngOnInit() {}

  emitChange($event) {
    this.change.emit($event);
  }
}
