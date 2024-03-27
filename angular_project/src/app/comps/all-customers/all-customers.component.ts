import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from 'src/app/classes/customer';
import { CustomerService } from 'src/app/ser/customer.service';

@Component({
  selector: 'app-all-customers',
  templateUrl: './all-customers.component.html',
  styleUrls: ['./all-customers.component.css']
})
export class AllCustomersComponent implements OnInit {
  constructor(public custService:CustomerService,public routing:Router) {
    
  }
  listCustomers:Array<Customer>=new Array<Customer>()
  ngOnInit(): void {
    
   this.custService.getAllCustomers()
   .subscribe(
    succ=>{
      console.log(succ);
     this.listCustomers=succ
    },
    err=>{
      console.log(err);
      
    }
   )
  }
  openDeatails(id:Number){
   this.routing.navigate([`./deatails/${id}`])
  }
  addCustomer(){
    this.routing.navigate(['./addCustomer'])
  }

}
