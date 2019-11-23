import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.less']
})
export class CheckboxComponent implements OnInit {

  @Input() off: string;
  @Input() on: string;

  constructor() { }

  ngOnInit() {
  }

}
