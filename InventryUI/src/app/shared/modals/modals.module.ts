import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';
import { SuccessComponent } from './success/success.component';
import { ErrorComponent } from './error/error.component';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';
import { ErrorModalComponent } from './error-modal/error-modal.component';
import { SuccessModalComponent } from './success-modal/success-modal.component';
import { ModalModule } from 'ngx-bootstrap/modal';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    ModalModule.forRoot()
  ],
  exports: [
    SuccessComponent,
    ErrorComponent,
    ConfirmDeleteComponent,
    ErrorModalComponent,
    SuccessModalComponent,
  ],
  declarations: 
  [
    SuccessComponent,
    ErrorComponent,
    ConfirmDeleteComponent,
    ErrorModalComponent,
    SuccessModalComponent,
  ]
})
export class ModalsModule { }
