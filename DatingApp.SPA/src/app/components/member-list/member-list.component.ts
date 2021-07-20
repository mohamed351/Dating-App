import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/userModels';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
 public  users:UserModel[] = [];
  constructor(private userService:UserService, private router:Router) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(userData=>{
      console.log(userData);
      this.users = userData;
    });
  }
  userDetailsClicked(data:any){
  
    this.router.navigate(["/member",data]);

  }

}
