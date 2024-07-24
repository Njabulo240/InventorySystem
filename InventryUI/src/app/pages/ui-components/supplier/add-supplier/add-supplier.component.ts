import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Supplier } from 'src/app/_interface/inventory/supplier';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-add-supplier',
  templateUrl: './add-supplier.component.html',
  styleUrls: ['./add-supplier.component.css']
})
export class AddSupplierComponent implements OnInit {

  public supplierForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService
  ) { }

  ngOnInit(): void {
    this.supplierForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      contactInfo: new FormControl('', [Validators.maxLength(100)])
    });
  }

  validateControl = (controlName: string) => {
    if (this.supplierForm.get(controlName).invalid && this.supplierForm.get(controlName).touched)
      return true;
    
    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.supplierForm.get(controlName).hasError(errorName))
      return true;
    
    return false;
  }

  createSupplier = (supplierFormValue: any) => {
    if (this.supplierForm.valid)
      this.executeSupplierCreation(supplierFormValue);
  }

  private executeSupplierCreation = (supplierFormValue: any) => {
    const supplier: Supplier = {
      name: supplierFormValue.name,
      contactInfo: supplierFormValue.contactInfo
    };

    const apiUrl = 'api/suppliers';
    this.repository.create(apiUrl, supplier)
      .subscribe({
        next: (createdSupplier: any) => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Supplier: ${createdSupplier.name} created successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToSupplierList());
        },
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  redirectToSupplierList = () => {
    this.router.navigate(['/ui-components/supplier']);
  }

}
