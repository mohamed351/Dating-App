import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS}from  '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
export class ErrorInterceptor implements HttpInterceptor{
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError((error, caught)=>{
                console.log(error);
         
                if(error.status == 401){
                    console.log((error.statusText));
                    return  throwError(error.statusText);
                }
                if(error.status == 400 && typeof error.error == "object"){
               
                   let errorMessage = "";
                   for (const key in error.error.errors) {
                     
                       errorMessage+=  error.error.errors[key] + "\n";
                   }
                   return  throwError(errorMessage);
                   
                }
                return  throwError("unbknow");
            })
        )
    }

}

