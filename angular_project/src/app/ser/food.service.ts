import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FoodService {

  constructor(public h:HttpClient) { }
  basisUrl:string="https://localhost:7061/api/Foods/"
  // getByIdC(id:number):Observable<Array<Food>>{
  //   return this.h.get<Array<Food>>(`https://localhost:7061/api/Foods/GetFoodByIdCategory/${id}`)
  // }
 /* getAll():Observable<Array<Food>>{
    //מומלץ להגדיר משתנה המכיל את הבסיס של הניתוב
    //ובכל פונקציה נשתמש במשתנה ונוסיף את שם הפונקציה
    return this.h.get<Array<Food>>(`${this.basisUrl}MyGetAllFoods`)
  }
  del(id:number):Observable<Array<Food>>{
    return this.h.delete<Array<Food>>(`${this.basisUrl}mydelateFood/${id}`)
  }
  add(f:Food)
  {
    //body משתנה הנשלח ב
    // נוסיף פסיק ושם המשתנה
    return this.h.post<Array<Food>>(`${this.basisUrl}addFood`,f)
  }
  */
}
