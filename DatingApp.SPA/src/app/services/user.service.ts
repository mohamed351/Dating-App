import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserModel } from '../models/userModels';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  // headers:HttpHeaders = new HttpHeaders({
  //      'Authorization':'Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkR1bmNhbiBMbG95ZCIsImVtYWlsIjoiZHVuY2FubGxveWRAc2NlbnRyaWMuY29tIiwibmFtZWlkIjoiNiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiKzEgKDgwMSkgNTQwLTM5NjQiLCJuYmYiOjE2MjY3MDg4NTAsImV4cCI6MTYyNjc5NTI1MCwiaWF0IjoxNjI2NzA4ODUwfQ.ZLdN2VzbI0FOAXdwzBuEKZYydzMFWopeKOwj__QEhuIriKD6ZXQtT665Ra3XW4uktXwZiL8Bu_GD7wwRlh-0RA'
  // });
  constructor(private http:HttpClient) { }

  getUsers(): Observable<UserModel[]>{
    return this.http.get<UserModel[]>(environment.URL+"/api/Users");
  }
  getUser(id:number):Observable<UserModel>{
    return this.http.get<UserModel>(environment.URL+`/api/Users/${id}`);
  }
}
