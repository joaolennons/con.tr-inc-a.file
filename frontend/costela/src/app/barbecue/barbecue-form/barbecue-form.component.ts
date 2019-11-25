import { Component, OnInit, ViewEncapsulation } from "@angular/core";
import { FormArray, FormGroup, FormBuilder } from "@angular/forms";
import { Barbecue } from "../models/barbecue.model";
import { BarbecueService } from "../barbecue.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Participant } from "../models/participant.model";
import { Literals } from "./localization/barbecue-form-pt-br";
import { DrinkingOption } from "./barbecue-form.consts";

@Component({
  selector: "app-barbecue-form",
  templateUrl: "./barbecue-form.component.html",
  styleUrls: ["./barbecue-form.component.less"],
  encapsulation: ViewEncapsulation.None
})
export class BarbecueFormComponent implements OnInit {
  private _participants: Array<Participant> = [];

  public readonly literals = Literals;
  public readonly: boolean;
  public eligibleParticipants: Array<Participant>;
  public barbecue: Barbecue = new Barbecue();

  public savedAt = new Date();
  public barbecueForm: FormGroup;

  constructor(
    private service: BarbecueService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  public ngOnInit() {
    const id = this.activatedRoute.snapshot.params.id;

    if (id) {
      this.readonly = true;
      this.getBarbecue(id);
    }

    this.service.getEligibleParticipants().subscribe(
      people => (this.eligibleParticipants = people),
      error => console.error(error)
    );

    this.barbecueForm = this.fb.group({
      title: [],
      participants: this.fb.array([this.fb.group({ participant: "" })])
    });
  }

  public getBarbecue(id: string) {
    this.service.get(id).subscribe(
      bbq => {
        this.barbecue = bbq;
        if (this.readonly) {
          this._participants = [];
          this._clearFormArray(this.participants);
          bbq.participants.forEach(o => {
            o.drinking = o.value === DrinkingOption.drinking;
            this._add(o);
            this.participants.push(this.fb.group({ participant: "" }));
          });
          this.participants.push(this.fb.group({ participant: "" }));
        } else {
          this.updateParticipants(bbq.participants);
        }
      },
      error => console.error(error)
    );
  }

  public giveUp() {
    if (this.barbecue.id) {
      this.service.delete(this.barbecue.id).subscribe(
        () => this.goToList(),
        error => console.error(error)
      );
    }
  }

  public goToList() {
    this.router.navigateByUrl("");
  }

  public updateParticipants(participants: Participant[]) {
    this._participants.forEach(participant => {
      const updated = participants.find(o => o.id === participant.id);
      participant.paid = updated.paid;
      participant.value = updated.value;
      participant.drinking = updated.value === DrinkingOption.drinking;
    });
  }

  public editBarbecue() {
    if (!this.barbecue.id) {
      this.service.post(this.barbecue).subscribe(
        bbq => {
          this.barbecue = bbq;
          this.getBarbecue(bbq.id);
        },
        error => console.error(error)
      );
    } else {
      this.service.put(this.barbecue).subscribe(
        bbq => {
          this.barbecue = bbq;
          this.getBarbecue(bbq.id);
        },
        error => console.error(error)
      );
    }
  }

  public get participants() {
    return this.barbecueForm.get("participants") as FormArray;
  }

  public filterData() {
    return this.eligibleParticipants
      ? this.eligibleParticipants.filter(
          o => !this._participants.find(w => w.id === o.id)
        )
      : [];
  }

  public addParticipant(participant: any) {
    if (this.readonly) return;
    this.service.addParticipant(this.barbecue.id, participant).subscribe(
      () => {
        this._add(participant);
        this.participants.push(this.fb.group({ participant: "" }));
        this.getBarbecue(this.barbecue.id);
      },
      error => console.error(error)
    );
  }

  public removeParticipant(index) {
    if (this.exists(index)) {
      const participant = this._participants[index];
      this.service
        .removeParticipant(this.barbecue.id, participant.id, participant.paid)
        .subscribe(
          () => {
            this._remove(index);
            this.participants.removeAt(index);

            if (this._participants.length === 0) {
              this._clearFormArray(this.participants);
              this.participants.push(this.fb.group({ participant: "" }));
            }

            this.getBarbecue(this.barbecue.id);
          },
          error => console.error(error)
        );
    }
  }

  public changeDrinkingOption(item) {
    const participant = this._participants[item];
    this.service
      .changeDrinkingOption(this.barbecue.id, {
        participantId: participant.id,
        drinking: !participant.drinking,
        paid: participant.paid
      })
      .subscribe(
        () => {
          this.getBarbecue(this.barbecue.id);
        },
        error => console.error(error)
      );
  }

  public setPayment(paid, index) {
    const participant = this._participants[index];
    this.service
      .setPayment(this.barbecue.id, participant.id, { paid: paid })
      .subscribe(
        () => {
          this.getBarbecue(this.barbecue.id);
        },
        error => console.error(error)
      );
  }

  public exists(index) {
    return this._participants[index];
  }

  public enableEditing() {
    this.readonly = false;
  }

  private _add(participant: any) {
    this._participants.push(participant);
  }

  private _remove(participant: number) {
    this._participants.splice(participant, 1);
  }

  private _clearFormArray = (formArray: FormArray) => {
    while (formArray.length !== 0) {
      formArray.removeAt(0);
    }
  };
}
