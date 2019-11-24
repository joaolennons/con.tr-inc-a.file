import { Component, OnInit, Output, EventEmitter, Input, forwardRef, ChangeDetectorRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-participant',
  templateUrl: './participant.component.html',
  styleUrls: ['./participant.component.less'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: forwardRef(() => ParticipantComponent),
    }
  ]
})
export class ParticipantComponent implements ControlValueAccessor {

  private level: string;
  private disabled: boolean;
  private onChange: Function;
  private onTouched: Function;
  @Input() readonly: boolean;

  constructor(private cd: ChangeDetectorRef) {
    this.onChange = (_: any) => { };
    this.onTouched = () => { };
    this.disabled = false;
  }

  public ngAfterViewInit() {
    this.cd.detectChanges();
  }

  public isActive(value: string): boolean {
    return value === this.level;
  }

  public setLevel(value: string): void {
    this.level = value;
    this.onChange(this.level);
    this.onTouched();
  }

  writeValue(obj: any): void {
    this.level = obj;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  @Input() public data: Array<any>[];
  @Output() add = new EventEmitter<any>();
  @Output() remove = new EventEmitter<any>();

  ngOnInit() {
  }

  public emitAdd($event) {
    this.add.emit($event);
  }

  public emitRemove($event) {
    this.remove.emit($event);
  }

}
