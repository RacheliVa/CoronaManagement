import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../classes/customer';
import { disase } from '../classes/disease';
import { vaccination } from '../classes/vaccination';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(public http:HttpClient) { }
  baseUrl:string ="https://localhost:7278/api/"
  getAllCustomers():Observable<Array<Customer>>{
    return this.http.get<Array<Customer>>(`${this.baseUrl}Customer`)
  }
  getCustomerById(id:Number):Observable<Customer>{
    return this.http.get<Customer>(`${this.baseUrl}Customer/${id}`)
  }
  getDiseaseByCustomerId(id:Number):Observable<disase>{
    return this.http.get<disase>(`${this.baseUrl}Disease/${id}`)
  }
  getVaccinationsByCustomer(id:Number):Observable<Array<vaccination>>{
    return this.http.get<Array<vaccination>>(`${this.baseUrl}Customer/getVaccination/${id}`)
  }
  addCustomer(newCustomer:Customer):Observable<Customer>{
    return this.http.post<Customer>(`${this.baseUrl}Customer`,newCustomer)
  }
  updateCustomer(customerToUpdate:Customer):Observable<boolean>{
    return this.http.put<boolean>(`${this.baseUrl}Customer/updateCustomer`,customerToUpdate)
  }
  deleteCustomer(id:Number):Observable<boolean>{
    return this.http.delete<boolean>(`${this.baseUrl}Customer/${id}`)
  }
  addDiseaseToCustomer(disase:disase):Observable<disase>{
    return this.http.post<disase>(`${this.baseUrl}Disease`,disase)
  }
  addVaccinationToCustomer(vaccination:vaccination):Observable<boolean>{
    return this.http.post<boolean>(`${this.baseUrl}Vaccination`,vaccination)
  }
}
