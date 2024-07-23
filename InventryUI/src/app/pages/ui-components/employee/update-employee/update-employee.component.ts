import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent implements OnInit {

  public employeeForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  private employeeId: string | null = '';

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.employeeId = this.route.snapshot.paramMap.get('id');
    this.employeeForm = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      employeeNumber: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      position: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      email: new FormControl('', [Validators.required, Validators.email])
    });
    this.initializeForm();
  }

  private initializeForm = () => {
    if (this.employeeId) {
      this.repository.getData(`api/employees/${this.employeeId}`)
        .subscribe({
          next: (employee: any) => {
            this.employeeForm = new FormGroup({
              firstName: new FormControl(employee.firstName, [Validators.required, Validators.maxLength(60)]),
              lastName: new FormControl(employee.lastName, [Validators.required, Validators.maxLength(60)]),
              employeeNumber: new FormControl(employee.employeeNumber, [Validators.required, Validators.maxLength(60)]),
              position: new FormControl(employee.position, [Validators.required, Validators.maxLength(60)]),
              email: new FormControl(employee.email, [Validators.required, Validators.email])
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
    if (this.employeeForm.get(controlName).invalid && this.employeeForm.get(controlName).touched)
      return true;
    
    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.employeeForm.get(controlName).hasError(errorName))
      return true;
    
    return false;
  }

  updateEmployee = (employeeFormValue: any) => {
    if (this.employeeForm.valid)
      this.executeEmployeeUpdate(employeeFormValue);
  }

  private executeEmployeeUpdate = (employeeFormValue: any) => {
    const updatedEmployee = {
      id: this.employeeId ? this.employeeId : '',
      firstName: employeeFormValue.firstName,
      lastName: employeeFormValue.lastName,
      employeeNumber: employeeFormValue.employeeNumber,
      position: employeeFormValue.position,
      email: employeeFormValue.email
    };

    const apiUrl = `api/employees/${this.employeeId}`;
    this.repository.update(apiUrl, updatedEmployee)
      .subscribe({
        next: () => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Employee: ${updatedEmployee.firstName} ${updatedEmployee.lastName} updated successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToEmployeeList());
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
