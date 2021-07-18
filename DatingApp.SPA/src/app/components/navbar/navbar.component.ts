import { Component, OnInit } from '@angular/core';
import { loginModel } from 'src/app/models/loginModel';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  userInfo:loginModel = {
    userName:null,
    password:null
  };
  constructor(public auth:AuthService, private alertfiy:AlertifyService) { }

  ngOnInit(): void {
  }
  loginData(){
    this.auth.login(this.userInfo).subscribe(user =>{
        console.log("userInfo",user);
        this.alertfiy.success("successfull login");
    },(error) =>{
      this.alertfiy.error(error);
    });
  }
  logoutUser(){
    this.auth.logout();
  }

}
