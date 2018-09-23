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
  MatToolbarModule
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
    MatToolbarModule
  ]
})
export class MaterialModule { }
