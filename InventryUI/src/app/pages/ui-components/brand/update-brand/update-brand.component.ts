import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-brand',
  templateUrl: './update-brand.component.html',
  styleUrls: ['./update-brand.component.css']
})
export class UpdateBrandComponent implements OnInit {

  public brandForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  private brandId: string;

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private route: ActivatedRoute,
    private modal: BsModalService
  ) { }

  ngOnInit(): void {
    this.brandId = this.route.snapshot.paramMap.get('id')!;
    this.loadBrand();
    this.brandForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)])
    });
  }

  private loadBrand = () => {
    const apiUrl = `api/brands/${this.brandId}`;
    this.repository.getData(apiUrl)
      .subscribe({
        next: (brand: any) => {
          this.brandForm.patchValue(brand);
        },
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
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

  updateBrand = (brandFormValue: any) => {
    if (this.brandForm.valid)
      this.executeBrandUpdate(brandFormValue);
  }

  private executeBrandUpdate = (brandFormValue: any) => {
    const brand: any = {
      name: brandFormValue.name
    };

    console.log(brand);
    const apiUrl = `api/brands/${this.brandId}`;
    this.repository.update(apiUrl, brand)
      .subscribe({
        next: () => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Brand updated successfully`,
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
