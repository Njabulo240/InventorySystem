import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';
import { SuccessComponent } from './success/success.component';
import { ErrorComponent } from './error/error.component';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule
  ],
  exports: [
    SuccessComponent,
    ErrorComponent,
    ConfirmDeleteComponent,
  ],
  declarations: 
  [
    SuccessComponent,
    ErrorComponent,
    ConfirmDeleteComponent,
  ]
})
export class ModalsModule { }
