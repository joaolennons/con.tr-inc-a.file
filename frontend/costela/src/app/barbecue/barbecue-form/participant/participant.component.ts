import {
  Component,
  Output,
  EventEmitter,
  Input,
  forwardRef,
  ChangeDetectorRef
} from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";

@Component({
  selector: "app-participant",
  templateUrl: "./participant.component.html",
  styleUrls: ["./participant.component.less"],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: forwardRef(() => ParticipantComponent)
    }
  ]
})
export class ParticipantComponent implements ControlValueAccessor {
  private level: string;
  private disabled: boolean;
  private onChange: Function;
  private onTouched: Function;
  @Input() readonly: boolean;
  @Input() value: any;
  @Input() drinking: boolean;
  @Input() paymentStatus: boolean;
  @Input() data: Array<any>[];
  @Output() add = new EventEmitter<any>();
  @Output() remove = new EventEmitter<any>();
  @Output() paid = new EventEmitter<any>();
  @Output() changeDrinkingOption = new EventEmitter<any>();
  @Output() focus = new EventEmitter<any>();

  constructor(private cd: ChangeDetectorRef) {
    this.onChange = (_: any) => {};
    this.onTouched = () => {};
    this.disabled = false;
  }

  ngOnInit() {}

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

  public writeValue(obj: any): void {
    this.level = obj;
  }

  public registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  public registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  public setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  public emitAdd($event) {
    this.add.emit($event);
  }

  public emitRemove($event) {
    this.remove.emit($event);
  }

  public emitChange($event) {
    this.changeDrinkingOption.emit($event);
  }

  public emitFocus() {
    this.focus.emit();
  }

  public emitSetPayment($event) {
    this.paid.emit($event);
  }
}
