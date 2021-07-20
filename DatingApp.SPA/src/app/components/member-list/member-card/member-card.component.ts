import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UserModel } from 'src/app/models/userModels';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
   @Input("user") userCard:UserModel |null = null;
   @Output("userClickedDetails") userDetailsHandler = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
    
  }
  clickDetails(){
    this.userDetailsHandler.emit(this.userCard?.id);
  }

}
