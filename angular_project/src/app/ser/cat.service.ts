import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
// import { Category } from '../classes/category';

@Injectable({
  providedIn: 'root'
})
export class CatService {

  //HttpClient הזרקת משתנה המכיל פונקציה בקשה לשרת
  constructor(public http:HttpClient) { }

  // \Observable - ניתן לצפיה
  // אפשר לחכות שפונקציה זו תחזיר מידע מאוחר יותר
  /*getAllCategory():Observable<Array<Category>>
  {
    // על המשתנה המוזרק אפשר להפעיל כל אחת מהבקשות
    //ובסוגריים לשלוח ניתוב
    // מיד אחרי סוג הבקשה נגדיר מה יחזור
    return this.http.get<Array<Category>>("https://localhost:7061/api/Caregories/getAll")
  }
  */
}
