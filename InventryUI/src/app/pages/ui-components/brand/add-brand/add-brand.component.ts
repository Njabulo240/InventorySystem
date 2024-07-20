import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-add-brand',
  templateUrl: './add-brand.component.html',
  styleUrls: ['./add-brand.component.css']
})
export class AddBrandComponent implements OnInit {
  public brandForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService
  ) { }

  ngOnInit(): void {
    this.brandForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)])
    });
  }

  validateControl = (controlName: string) => {
    if (this.brandForm.get(controlName).invalid && this.brandForm.get(controlName).touched)
      return true;
    
    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.brandForm.get(controlName).hasError(errorName))
      return true;
    
    return false;
  }

  createBrand = (brandFormValue: any) => {
    if (this.brandForm.valid)
      this.executeBrandCreation(brandFormValue);
  }

  private executeBrandCreation = (brandFormValue: any) => {
    const brand: any = {
      name: brandFormValue.name
    };

    console.log(brand);
    const apiUrl = 'api/brands';
    this.repository.create(apiUrl, brand)
      .subscribe({
        next: (createdBrand: any) => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Brand: ${createdBrand.name} created successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe((_: any) => this.redirectToBrandList());
        },
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  redirectToBrandList = () => {
    this.router.navigate(['/ui-components/brand']);
  }

}
