import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-role',
  templateUrl: './update-role.component.html',
})
export class UpdateRoleComponent implements OnInit {

  public roleForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  private roleId: string | null = '';

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.roleId = this.route.snapshot.paramMap.get('id');
    this.roleForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(50)])
    });
    this.initializeForm();
  }

  private initializeForm = () => {
    if (this.roleId) {
      this.repository.getData(`api/roles/${this.roleId}`)
        .subscribe({
          next: (role: any) => {
            this.roleForm.setValue({
              name: role.name
            });
          },
          error: (err: HttpErrorResponse) => {
            this.errorHandler.handleError(err);
            this.errorMessage = this.errorHandler.errorMessage;
          }
        });
    }
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

  updateRole = (roleFormValue: any) => {
    if (this.roleForm.valid)
      this.executeRoleUpdate(roleFormValue);
  }

  private executeRoleUpdate = (roleFormValue: any) => {
    const updatedRole: any = {
      name: roleFormValue.name
    };

    const apiUrl = `api/roles/${this.roleId}`;
    this.repository.update(apiUrl, updatedRole)
      .subscribe({
        next: () => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Role updated successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToRoleList());
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
