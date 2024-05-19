import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatIconModule} from '@angular/material/icon';
import { HdrNavComponent } from './support/header.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatIconModule, HdrNavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'CompetitionMaster';
}
