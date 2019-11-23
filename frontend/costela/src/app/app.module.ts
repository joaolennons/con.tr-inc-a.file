import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BarbecueFormComponent } from './barbecue/barbecue-form/barbecue-form.component';
import { BarbecueListComponent } from './barbecue/barbecue-list/barbecue-list.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CheckboxComponent } from './shared/checkbox/checkbox.component';
import { AutoCompleteComponent } from './shared/auto-complete/auto-complete.component';
import { ParticipantComponent } from './barbecue/barbecue-form/participant/participant.component';
import { DrinkingOptionComponent } from './barbecue/barbecue-form/participant/drinking-option/drinking-option.component';
import { TrashCanComponent } from './shared/trash-can/trash-can.component';
import { BarbecueHeaderComponent } from './barbecue/barbecue-form/barbecue-header/barbecue-header.component';

@NgModule({
  declarations: [
    AppComponent,
    BarbecueFormComponent,
    BarbecueListComponent,
    CheckboxComponent,
    AutoCompleteComponent,
    ParticipantComponent,
    DrinkingOptionComponent,
    TrashCanComponent,
    BarbecueHeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AutocompleteLibModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

}
