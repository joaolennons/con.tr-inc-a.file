import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-drinking-option',
  templateUrl: './drinking-option.component.html',
  styleUrls: ['./drinking-option.component.less']
})
export class DrinkingOptionComponent implements OnInit {

  @Input() off: number;
  @Input() on: number;
  constructor() { }

  ngOnInit() {
  }

}
