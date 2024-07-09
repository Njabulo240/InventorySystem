import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { UserRoleCreationDto } from 'src/app/_interface/user';
import { DataService } from 'src/app/shared/services/data.service';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
})
export class AddRoleComponent implements OnInit {
  dataForm: FormGroup |any;

  constructor( 
    private repoService: RepositoryService,
    private toastr: ToastrService,
    private dataService: DataService,
    private dialogserve: DialogService,
    private Ref: MatDialogRef<AddRoleComponent>) {}

  ngOnInit() {
    this.dataForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
    });

  }

  public validateControl = (controlName: string) => {
    return this.dataForm?.get(controlName)?.invalid && this.dataForm?.get(controlName)?.touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.dataForm?.get(controlName)?.hasError(errorName)
  }

  public createData = (dataFormValue: any) => {

    if (this.dataForm.valid) {
      this.executeDataCreation(dataFormValue);

    }
  };
  private executeDataCreation = (dataFormValue: any) => {
    let data: UserRoleCreationDto = {
   
      name: dataFormValue.name,

    };
    const apiUri: string = `api/roles`;
    this.repoService.create(apiUri, data).subscribe(
      (res) => {
        this.dialogserve.openSuccessDialog("The role has been added successfully.")
        .afterClosed()
        .subscribe((res) => {
          this.dataService.triggerRefreshTab1();
          this.Ref.close([]);
        });
      },
      (error) => {
        this.toastr.error(error);
        this.Ref.close([]);
      }
    );
  };

  closeModal(){
    this.Ref.close([]);
  }

}
