import { Component } from '@angular/core';

import { HttpErrorResponse } from '@angular/common/http';
import { MatLabel, MatInput, MatFormField} from '@angular/material/input';
import { MatButton, MatFabButton, MatMiniFabButton, MatIconButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

// services
import { SingleUserService } from './single-user.service';

// model
import { BaseUser } from '../base-user';
import { map } from 'rxjs/internal/operators/map';


@Component({
  selector: 'app-single-user',
  standalone: true,
  imports: [MatLabel, MatInput, MatFormField,  MatButton, MatIcon, MatFabButton, MatMiniFabButton, MatIconButton],
  templateUrl: './single-user.component.html',
  styleUrl: './single-user.component.css'
})
export class SingleUserComponent {
  public workingUser: BaseUser = new BaseUser();
  //public thumbnail: string = "";


  constructor(private _userService: SingleUserService){}

  public GetUserFromCode(){
    
    let docObj:any = document.getElementById("codeInput");
    let codeToTry:string = "";

    if(docObj != undefined && docObj != null){
      codeToTry = docObj.value;
    }
    this._userService.getUserFromCode(codeToTry).subscribe(
      {
        next: (v) =>  this.LoadUserFromServer(v),
        error: (e) => {this.ClearAll(); console.error(e)},
        complete: () => console.info('complete') 
      }
    )
  }

  public GetUserFromTag(){
    
    let docObj:any = document.getElementById("tagInput");
    let tagToTry:string = "";

    if(docObj != undefined && docObj != null){
      tagToTry = docObj.value;
    }
    this._userService.getUserFromTag(tagToTry).subscribe(
      {
        next: (v) =>  this.LoadUserFromServer(v),
        error: (e) => {this.ClearAll(); console.error(e)},
        complete: () => console.info('complete') 
      }
    )
  }

  public LoadUserFromServer(retdata: any): void{
    console.log(retdata);
    
    this.workingUser = retdata;
    //this.thumbnail = this.workingUser.thumbnail;
  }

  public ClearAll(): void{
    this.workingUser = new BaseUser();
  }

  public ClearField(idNme: string): void{
    switch(idNme){
      case "codeInput":
        this.workingUser.code = "";
      break;
      case "tagInput":
        this.workingUser.tag = "";
      break;
      case "nameInput":
        this.workingUser.name = "";
      break;
    }
  }
}
