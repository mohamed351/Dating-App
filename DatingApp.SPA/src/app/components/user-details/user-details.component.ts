import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserModel } from 'src/app/models/userModels';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  userModel:UserModel|null = null;
  constructor(private activeRouter:ActivatedRoute, private userSerive:UserService) {

   }

  ngOnInit(): void {
    this.activeRouter.params.subscribe(options => {
       this.userSerive.getUser(options.id).subscribe(data=>{
         this.userModel = data;
       });
    });
  }

}
