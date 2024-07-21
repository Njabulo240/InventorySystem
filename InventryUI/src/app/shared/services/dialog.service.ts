import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDeleteComponent } from '../modals/confirm-delete/confirm-delete.component';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

 constructor(private dialog: MatDialog) {}

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