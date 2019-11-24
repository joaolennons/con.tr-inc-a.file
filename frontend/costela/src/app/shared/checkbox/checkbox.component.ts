import { Component, OnInit, Input, EventEmitter, Output } from "@angular/core";

@Component({
  selector: "app-checkbox",
  templateUrl: "./checkbox.component.html",
  styleUrls: ["./checkbox.component.less"]
})
export class CheckboxComponent implements OnInit {
  @Input() off: string;
  @Input() on: string;
  @Input() readonly: boolean;
  @Input() isChecked: boolean;
  @Output() checked = new EventEmitter<boolean>();

  constructor() {}

  ngOnInit() {}

  public emitChecked() {
    this.checked.emit(this.isChecked);
  }
}
