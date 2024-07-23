import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  public employeeForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService
  ) { }

  ngOnInit(): void {
    this.employeeForm = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      employeeNumber: new FormControl('', [Validators.required, Validators.maxLength(20)]),
      position: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      email: new FormControl('', [Validators.required, Validators.email])
    });
  }

  validateControl = (controlName: string) => {
    if (this.employeeForm.get(controlName).invalid && this.employeeForm.get(controlName).touched)
      return true;

    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.employeeForm.get(controlName).hasError(errorName))
      return true;

    return false;
  }

  createEmployee = (employeeFormValue: any) => {
    if (this.employeeForm.valid)
      this.executeEmployeeCreation(employeeFormValue);
  }

  private executeEmployeeCreation = (employeeFormValue: any) => {
    const employee: any = {
      firstName: employeeFormValue.firstName,
      lastName: employeeFormValue.lastName,
      employeeNumber: employeeFormValue.employeeNumber,
      position: employeeFormValue.position,
      email: employeeFormValue.email
    };

    const apiUrl = 'api/employees';
    this.repository.create(apiUrl, employee)
      .subscribe({
        next: (createdEmployee: any) => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Employee: ${createdEmployee.firstName} ${createdEmployee.lastName} created successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe((_: any) => this.redirectToEmployeeList());
        },
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  redirectToEmployeeList = () => {
    this.router.navigate(['/ui-components/employee']);
  }

}
