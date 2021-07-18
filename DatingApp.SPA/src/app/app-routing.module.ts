import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from './components/home/home.component';
import { ListsComponent } from './components/lists/lists.component';
import { MemberListComponent } from './components/member-list/member-list.component';
import { MessagesComponent } from './components/messages/messages.component';
import { AuthGuard } from './guards/auth.guard';


const routes: Routes = [
  {path:"", component:HomeComponent},{
    runGuardsAndResolvers:"always",
    canActivate:[AuthGuard],
    children:[
       {path:"memberList", component:MemberListComponent},
      {path:"lists", component:ListsComponent},
      {path:"messages",component:MessagesComponent} ]
    
  },
  {path:"**" , redirectTo:"",pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }