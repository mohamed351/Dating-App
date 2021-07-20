import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {ErrorInterceptor} from './interceptors/error-interceptor';
import { AlertifyService } from './services/alertify.service';
import { MemberListComponent } from './components/member-list/member-list.component';
import { MessagesComponent } from './components/messages/messages.component';
import { ListsComponent } from './components/lists/lists.component';
import { MemberCardComponent } from './components/member-list/member-card/member-card.component';
import { JwtModule } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { UserDetailsComponent } from './components/user-details/user-details.component';

function tokenGetter():string | null{
 let item = localStorage.getItem("token");
 console.log(item);
 return item == null ? null :JSON.parse(item).token;

}
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    MemberListComponent,
    MessagesComponent,
    ListsComponent,
    MemberCardComponent,
    UserDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains:[...environment.origins],
        disallowedRoutes:[...environment.notAllowedOrigin]
      },
    })
  ],
  providers: [{
    useClass:ErrorInterceptor,
    provide:HTTP_INTERCEPTORS,
    multi:true
  },AlertifyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
