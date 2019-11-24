import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BarbecueFormComponent } from './barbecue/barbecue-form/barbecue-form.component';
import { BarbecueListComponent } from './barbecue/barbecue-list/barbecue-list.component';

const routes: Routes = [
  { component: BarbecueListComponent, path: '' },
  { component: BarbecueFormComponent, path: 'new-bbq' },
  { component: BarbecueFormComponent, path: 'new-bbq/:id' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
