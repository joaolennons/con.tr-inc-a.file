import { Component, OnInit, Output, EventEmitter, Input } from "@angular/core";

@Component({
  selector: "app-trash-can",
  templateUrl: "./trash-can.component.html",
  styleUrls: ["./trash-can.component.less"]
})
export class TrashCanComponent implements OnInit {
  @Input() readonly: boolean;
  @Output() delete = new EventEmitter<any>();
  public hover: boolean;

  mouseIn() {
    this.hover = true;
  }

  mouseOut() {
    this.hover = false;
  }

  constructor() {}

  ngOnInit() {}

  emitDelete($event) {
    this.delete.emit($event);
  }
}
