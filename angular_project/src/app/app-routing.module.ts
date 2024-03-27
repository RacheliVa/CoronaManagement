import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllCustomersComponent } from './comps/all-customers/all-customers.component';
import { AddCustomerComponent } from './comps/add-customer/add-customer.component';
import { CustomerDeatailsComponent } from './comps/customer-deatails/customer-deatails.component';

const routes: Routes = [
  {path: '', component: AllCustomersComponent, },
  { path: 'addCustomer', component: AddCustomerComponent },
  { path: 'deatails/:id', component: CustomerDeatailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
