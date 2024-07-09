import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { UserForRegistrationDto, UserRoleDto } from 'src/app/_interface/user';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { DataService } from 'src/app/shared/services/data.service';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',

})
export class AddUserComponent implements OnInit {
  dataForm: FormGroup |any;
  roles:UserRoleDto []|any;
  selectedRoles: string[] = [];

  constructor( 
    private repoService: RepositoryService,
    private dataService: DataService,
    private toastr: ToastrService,
    private dialogserve: DialogService,
    private authService: AuthenticationService,
    private Ref: MatDialogRef<AddUserComponent>) {}

  ngOnInit() {
    this.dataForm = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      userName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      email: new FormControl('', [Validators.required, Validators.email]),
    });

    this.getRoles();

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
    let data: UserForRegistrationDto = {
   
      firstName: dataFormValue.firstName,
      lastName: dataFormValue.lastName,
      userName: dataFormValue.userName,
      email: dataFormValue.email,
      roles: this.selectedRoles

    };

    const apiUri: string = `api/authentication`;
    this.authService.registerUser(apiUri, data).subscribe(
      (res:any) => {

        this.dialogserve.openSuccessDialog("The default password is sent to the user's email address")
        .afterClosed()
        .subscribe((res) => {
          this.dialogserve.openSuccessDialog("The user has been added successfully.")
          .afterClosed()
          .subscribe((res) => {
            this.dataService.triggerRefreshTab1();
            this.Ref.close([]);
          });
        });
 
      },
      (error:HttpErrorResponse) => {
        this.dialogserve
        .openErrorDialog(error.message)
        .afterClosed()
        .subscribe((res) => {
        
        });
      }
    );
  };

  public getRoles(){
    this.repoService.getData('api/roles')
    .subscribe(res => {
      this.roles = res as UserRoleDto[];
      
    },
    (err) => {
      this.toastr.success(err);
    })
  }

  isSelected(roleName: string): boolean {
    return this.selectedRoles.includes(roleName);
  }

  toggleRoleSelection(event: any, roleName: string): void {
    if (event.checked) {
      this.selectedRoles.push(roleName);
    } else {
      this.selectedRoles = this.selectedRoles.filter(role => role !== roleName);
    }
  }

  closeModal(){
    this.Ref.close([]);
  }

}
