import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DynamicDialogModule, DynamicDialogConfig , DynamicDialogRef} from 'primeng/dynamicdialog';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DynamicDialogModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [DynamicDialogConfig, DynamicDialogRef]
})

export class AppComponent {
  title = 'Thaibev-Test';
}
