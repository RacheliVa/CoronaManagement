import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customer } from 'src/app/classes/customer';
import { CustomerService } from 'src/app/ser/customer.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit{
 
  constructor(public custSer:CustomerService,private formBuilder: FormBuilder) {
   
  }
  ngOnInit(): void {
    this.myForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      phone: ['', Validators.required],
      birthDate: ['', Validators.required],
      city: ['', Validators.required],
      street: ['', Validators.required],
      numHouse: ['', Validators.required]
    });
    throw new Error('Method not implemented.');
  }
 addCustomer(){
  console.log(this.newCustomer);
   this.custSer.addCustomer(this.newCustomer)
   .subscribe(
    succ=>{
       alert(succ.name)
    },
    err=>{
      console.log(err);    
    }
   )
 }
 newCustomer:Customer=new Customer()
 myForm: FormGroup=new FormGroup(7);
}
