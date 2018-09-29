import { NgModule } from '@angular/core';
import {
  MatTabsModule,
  MatListModule,
  MatMenuModule,
  MatInputModule,
  MatButtonModule,
  MatCardModule,
  MatIconModule,
  MatGridListModule,
  MatToolbarModule,
  MatTooltipModule,
  MatSnackBarModule
} from '@angular/material';

@NgModule({
  exports: [
    MatGridListModule,
    MatTabsModule,
    MatListModule,
    MatMenuModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatToolbarModule,
    MatTooltipModule,
    MatSnackBarModule
  ]
})
export class MaterialModule { }
