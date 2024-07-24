import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { UserForUpdateDto, UserRoleDto } from 'src/app/_interface/user/userForRegistrationDto.model';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
})
export class UpdateUserComponent implements OnInit {
  dataForm: FormGroup |any;
  roles:UserRoleDto []|any;
  selectedRoles: string[] = [];
  user:UserForUpdateDto |any;
  private userId: string | null = '';
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;

  constructor( 
    private repoService: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private toastr: ToastrService,
    private modal: BsModalService,
    private route: ActivatedRoute,
    private router: Router,) {}

  ngOnInit() {
    this.userId = this.route.snapshot.paramMap.get('id');
    this.dataForm = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      userName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      email: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });

    this.getRoles();
    this.getUsertoUpdate();
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
    let data: UserForUpdateDto = {
   
      firstName: dataFormValue.firstName,
      lastName: dataFormValue.lastName,
      userName: dataFormValue.userName,
      email: dataFormValue.email,
      roles: this.selectedRoles,

    };
    const Uri: string = `api/accounts/${this.userId}`;
    this.repoService.update(Uri, data).subscribe(
      (res) => {

        const config: ModalOptions = {
          initialState: {
            modalHeaderText: 'Success Message',
            modalBodyText: `${data.firstName} updated successfully`,
            okButtonText: 'OK'
          }
        };

        this.bsModalRef = this.modal.show(SuccessModalComponent, config);
        this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToUserList());

      },
      (error:HttpErrorResponse) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    );
  };

  public getRoles(){
    this.repoService.getData('api/roles')
    .subscribe(res => {
      this.roles = res as UserRoleDto[];
      
    },
    (error:HttpErrorResponse) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    }
  );
  }


  toggleRoleSelection(event: any, roleName: string): void {
    if (event.checked) {
      this.selectedRoles.push(roleName);
    } else {
      this.selectedRoles = this.selectedRoles.filter(role => role !== roleName);
    }
  }

  private getUsertoUpdate = () => {

    const Uri: string = `api/accounts/${this.userId}`;
    console.log(Uri);
    this.repoService.getData(Uri)
      .subscribe({
        next: (own: any) => {
          this.user = { ...own };
          this.dataForm.patchValue(this.user);
          this.selectedRoles = this.user.roles; 
        },
        error: (err:HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      })
  }

  isSelected(roleName: string): boolean {
    return this.selectedRoles.includes(roleName);
  }
  redirectToUserList = () => {
    this.router.navigate(['/ui-components/user']);
  }
}
