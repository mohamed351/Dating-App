import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm:FormGroup = new FormGroup({
    userName:new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required]),
    email:new FormControl('',[Validators.required,Validators.email]),
    phone:new FormControl('',[Validators.required])
  })

  get userName () {
    return this.registerForm.get("userName");
  }
  get password (){
    return this.registerForm.get("password");
  }
  get email (){
    return this.registerForm.get("email");
  }
  get phone (){
    return this.registerForm.get("phone");
  }
  constructor(private auth:AuthService) { }

  ngOnInit(): void {
   
  }
  cancelRegisterMode(){
    this.auth.registerMode = false;
  }
  registerUser(){

    this.auth.register(this.registerForm.value).subscribe(a=>{
      this.auth.login({
        userName:this.registerForm.value.userName,
        password: this.registerForm.value.password
      }).subscribe(c=>{
      
      });
    });
  }

}
