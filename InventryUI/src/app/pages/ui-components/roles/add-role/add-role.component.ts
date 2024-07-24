import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
})
export class AddRoleComponent implements OnInit {
  public roleForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService
  ) { }

  ngOnInit(): void {
    this.roleForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(50)])
    });
  }

  validateControl = (controlName: string) => {
    if (this.roleForm.get(controlName).invalid && this.roleForm.get(controlName).touched)
      return true;
    
    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.roleForm.get(controlName).hasError(errorName))
      return true;
    
    return false;
  }

  createRole = (roleFormValue: any) => {
    if (this.roleForm.valid)
      this.executeRoleCreation(roleFormValue);
  }

  private executeRoleCreation = (roleFormValue: any) => {
    const role: any = {
      name: roleFormValue.name
    };

    const apiUrl = 'api/roles';
    this.repository.create(apiUrl, role)
      .subscribe({
        next: (response: any) => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Role: ${response.role.name} created successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe((_: any) => this.redirectToRoleList());
        },
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  redirectToRoleList = () => {
    this.router.navigate(['/ui-components/roles']);
  }
}
