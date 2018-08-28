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
  MatExpansionModule
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
    MatExpansionModule
  ]
})
export class MaterialModule { }
