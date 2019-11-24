import { Component, OnInit, ViewEncapsulation, Input, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-auto-complete',
  templateUrl: './auto-complete.component.html',
  styleUrls: ['./auto-complete.component.less'],
  encapsulation: ViewEncapsulation.None
})
export class AutoCompleteComponent implements OnInit {

  @Input() public data: Array<any>[];
  @Input() public placeholder: string;
  @Input() public value: any;
  @Output() public add = new EventEmitter<any>();
  @Output() public remove = new EventEmitter<any>();
  @Output() public focus = new EventEmitter<any>();
  constructor() {

  }

  ngOnInit() {
  }

  keyword = 'name';


  selectEvent(item) {
    this.add.emit(item);
  }

  removeEvent(item) {
    this.remove.emit(item);
  }

  emitFocus(item) {
    this.focus.emit(item);
  }
}
