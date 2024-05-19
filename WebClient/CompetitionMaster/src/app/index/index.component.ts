import { Component } from '@angular/core';
import { Router } from '@angular/router';



@Component({
  selector: 'app-index',
  standalone: true,
  imports: [],
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent {

  constructor(private _router: Router){

  }

  public openSingleUser(): void{
    this._router.navigate(['/single-user', 0]);
  }
}
