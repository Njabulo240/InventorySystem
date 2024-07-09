import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDeleteComponent } from '../modals/confirm-delete/confirm-delete.component';
import { ErrorComponent } from '../modals/error/error.component';
import { SuccessComponent } from '../modals/success/success.component';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

 constructor(private dialog: MatDialog) {}

 openSuccessDialog(msg: any) {
  return this.dialog.open(SuccessComponent, {
    width: '350px',
    height: '220px',
    panelClass: 'success-dialog-container',
    disableClose: true,
    position: { top: '200px' },
    data: {
      message: msg,
    },
  });
}

openErrorDialog(msg: any) {
  return this.dialog.open(ErrorComponent, {
    width: '400px',
    height: '270px',
    panelClass: 'success-dialog-container',
    disableClose: true,
    position: { top: '200px' },
    data: {
      message: msg,
    },
  });
}

openConfirmDialog(msg: any) {
  return this.dialog.open(ConfirmDeleteComponent, {
    width: '300px',
    height: '150px',
    panelClass: 'success-dialog-container',
    disableClose: true,
    position: { top: '200px' },
    data: {
      message: msg,
    },
  });
}

}