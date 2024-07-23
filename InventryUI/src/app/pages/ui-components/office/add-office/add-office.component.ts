import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-add-office',
  templateUrl: './add-office.component.html',
  styleUrls: ['./add-office.component.css']
})
export class AddOfficeComponent implements OnInit {

  public officeForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService
  ) { }

  ngOnInit(): void {
    this.officeForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      location: new FormControl('', [Validators.maxLength(100)])
    });
  }

  validateControl = (controlName: string) => {
    if (this.officeForm.get(controlName).invalid && this.officeForm.get(controlName).touched)
      return true;
    
    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.officeForm.get(controlName).hasError(errorName))
      return true;
    
    return false;
  }

  createOffice = (officeFormValue: any) => {
    if (this.officeForm.valid)
      this.executeOfficeCreation(officeFormValue);
  }

  private executeOfficeCreation = (officeFormValue: any) => {
    const office: any = {
      name: officeFormValue.name,
      location: officeFormValue.location
    };

    const apiUrl = 'api/offices';
    this.repository.create(apiUrl, office)
      .subscribe({
        next: (createdOffice: any) => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Office: ${createdOffice.name} created successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe((_: any) => this.redirectToOfficeList());
        },
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  redirectToOfficeList = () => {
    this.router.navigate(['/ui-components/office']);
  }

}
