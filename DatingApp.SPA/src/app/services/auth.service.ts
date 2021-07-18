import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { loginModel } from '../models/loginModel';
import {environment} from '../../environments/environment';
import {map} from 'rxjs/operators';
import { RegisterModel } from '../models/registerModel';
import { JwtHelperService } from "@auth0/angular-jwt";
@Injectable({
  providedIn: 'root'
})
export class AuthService {
 
  registerMode = false;
  decodedToken:any;
   

  constructor(private http:HttpClient) { }

  login(loginData:loginModel){
   return this.http.post(environment.URL+"/api/Auth/Login",loginData).pipe(
      map((data:any)=>{
        localStorage.setItem("token",JSON.stringify( data));
        this.registerMode = false;
        const helper = new JwtHelperService();
        this.decodedToken = helper.decodeToken(data?.token)
        return data;
      })
    );
  }
  register(registerData:RegisterModel){
    return this.http.post(environment.URL+"/api/auth/register",registerData).pipe(map(data=>{
      this.registerMode = false;
      return data;
    }));
  }
  isLoggedIn(){
    let token = localStorage.getItem("token");
    const helper = new JwtHelperService();
    if(token != null){

    return !helper.isTokenExpired( JSON.parse(token).token);
    }
    else{
      return false;
    }
   
  }
  logout(){
    localStorage.removeItem("token");
  }
  refreshToken(){
    console.log(localStorage.getItem("token"));
    if(this.isLoggedIn() && localStorage.getItem("token")){
       let token  =localStorage.getItem("token")
       if(token != null){
        const helper = new JwtHelperService();
        this.decodedToken = helper.decodeToken( JSON.parse(token).token);
       }
    }
   }
  
}
