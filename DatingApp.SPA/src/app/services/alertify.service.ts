import {Injectable} from '@angular/core';
import * as aletify from 'alertifyjs';
@Injectable({
    providedIn:"root"
})
export class AlertifyService {
 
    /**
     *
     */
    constructor() {
      
        
    }

    confirm(message:string, okCallback : ()=> any){
        aletify.confirm(message,(e:any)=>{
            if(e){
                okCallback();
            } 
        });
    }
    success(message:string){
        aletify.success(message);
    }
    error(message:String){
        aletify.error(message);
    }

}