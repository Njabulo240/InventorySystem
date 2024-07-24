import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Supplier } from 'src/app/_interface/inventory/supplier';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-supplier',
  templateUrl: './update-supplier.component.html',
  styleUrls: ['./update-supplier.component.css']
})
export class UpdateSupplierComponent implements OnInit {

  public supplierForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  private supplierId: string | null = '';

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.supplierId = this.route.snapshot.paramMap.get('id');
    this.supplierForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      contactInfo: new FormControl('', [Validators.maxLength(100)])
    });
    this.initializeForm();
  }

  private initializeForm = () => {
    if (this.supplierId) {
      this.repository.getData(`api/suppliers/${this.supplierId}`)
        .subscribe({
          next: (supplier: any) => {
            this.supplierForm = new FormGroup({
              name: new FormControl(supplier.name, [Validators.required, Validators.maxLength(100)]),
              contactInfo: new FormControl(supplier.contactInfo, [Validators.maxLength(100)])
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
    if (this.supplierForm.get(controlName).invalid && this.supplierForm.get(controlName).touched)
      return true;
    
    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.supplierForm.get(controlName).hasError(errorName))
      return true;
    
    return false;
  }

  updateSupplier = (supplierFormValue: any) => {
    if (this.supplierForm.valid)
      this.executeSupplierUpdate(supplierFormValue);
  }

  private executeSupplierUpdate = (supplierFormValue: any) => {
    const updatedSupplier: Supplier = {
      id: this.supplierId ? this.supplierId : '',
      name: supplierFormValue.name,
      contactInfo: supplierFormValue.contactInfo
    };

    const apiUrl = `api/suppliers/${this.supplierId}`;
    this.repository.update(apiUrl, updatedSupplier)
      .subscribe({
        next: () => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Supplier: ${updatedSupplier.name} updated successfully`,
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
