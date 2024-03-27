import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/classes/customer';
import { disase } from 'src/app/classes/disease';
import { vaccination } from 'src/app/classes/vaccination';
import { CustomerService } from 'src/app/ser/customer.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-customer-deatails',
  templateUrl: './customer-deatails.component.html',
  styleUrls: ['./customer-deatails.component.css']
})
export class CustomerDeatailsComponent implements OnInit {

  constructor(public route: ActivatedRoute, public custService: CustomerService,public routing:Router) {

  }
  ngOnInit(): void {
    var custId = 0
    this.route.paramMap.subscribe(params => {
      custId = Number(params.get('id'))
    })
    console.log(custId);
    this.custService.getCustomerById(custId)
      .subscribe(succ => {
        this.currentCustomer = succ
      },
        err => {
          console.log(err);
        }

      )
    this.custService.getDiseaseByCustomerId(custId)
      .subscribe(
        succ => {
          console.log(succ);
          this.diseaseCustomer = succ
        }
        , err => {
          console.log(err);
        }
      )
    this.custService.getVaccinationsByCustomer(custId)
      .subscribe(
        succ => {
          console.log(succ);     
          this.listVaccination = succ
          console.log(this.listVaccination.length);
        },
        err => {
          console.log(err);
        }
      )
  }
  deleteCustomer(){
    this.custService.deleteCustomer(this.currentCustomer.id!)
    .subscribe(
      succ=>{
          alert(succ)
          this.routing.navigate(['./'])
      },
      err=>{
        console.log(err);  
        alert("failed!")   
      }
    )
  }
  openUpdate(){
    this.openDetails=true
  }
  updateCustomer()
  {
     this.custService.updateCustomer(this.currentCustomer)
     .subscribe(
      succ=>{
         alert(succ)
      },
      err=>{
        console.log(err);       
      }
     )
  }
  openDisease()
  {
    this.openAddDisease=true
  }
  closeDisease(){
    this.openAddDisease=false
  }
  addDisease(){
    this.disease.custId=this.currentCustomer.id
    if(this.disease.dateIn!<this.disease.dateOut!){
   this.custService.addDiseaseToCustomer(this.disease)
   .subscribe(
    succ=>{
      Swal.fire({
        title: "Succes!",
        text: "add disease worked!",
        icon: "success"
      });
    },
    err=>{
      Swal.fire({
        icon: "error",
        title: "Oops...",
              text: "Something went wrong!",

      });
    }
   )}
   else{
    Swal.fire({
      icon: "error",
      title: "Oops...",
      text: "תאריך החלמה קטן מתאריך מחלה",
    });
   }
  }
  openVaccination(){
    this.openAddVaccination=true
  }
  closeVaccination(){
    this.openAddVaccination=false
  }
  addVaccination()
  {
   this.vaccination.custId=this.currentCustomer.id
    this.custService.addVaccinationToCustomer(this.vaccination)
    .subscribe(
      succ=>{
        Swal.fire({
          title: "Succes!",
          text: "add vaccination worked!",
          icon: "success"
        });
      },
      err=>{
        Swal.fire({
          icon: "error",
          title: "Oops...",
          text: "Something went wrong!",
        });
      }
    )
  }
  currentCustomer: Customer = new Customer()
  diseaseCustomer: disase = new disase()
  listVaccination: Array<vaccination> = new Array()
  openDetails:boolean=false
  openAddDisease:boolean=false
  disease:disase= new disase()
  openAddVaccination:boolean=false
  vaccination:vaccination= new vaccination()
}
