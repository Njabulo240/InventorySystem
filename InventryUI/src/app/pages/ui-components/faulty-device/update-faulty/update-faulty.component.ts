import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-faulty',
  templateUrl: './update-faulty.component.html',
  styleUrls: ['./update-faulty.component.css']
})
export class UpdateFaultyComponent implements OnInit {

  public deviceForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  private deviceId: string | null = '';
  public categories: any[] = [];
  public brands: any[] = [];
  public suppliers: any[] = [];

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.deviceId = this.route.snapshot.paramMap.get('id');
    this.deviceForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      serialNumber: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      categoryId: new FormControl('', [Validators.required]),
      brandId: new FormControl('', [Validators.required]),
      supplierId: new FormControl('', [Validators.required]),
      isFaulty: new FormControl(false)
    });
    this.initializeForm();
    this.getCategories();
    this.getBrands();
    this.getSuppliers();
  }

  private initializeForm = () => {
    if (this.deviceId) {
      this.repository.getData(`api/devices/${this.deviceId}`)
        .subscribe({
          next: (device: any) => {
            this.deviceForm.patchValue({
              name: device.name,
              serialNumber: device.serialNumber,
              categoryId: device.categoryId,
              brandId: device.brandId,
              supplierId: device.supplierId,
              isFaulty: device.isFaulty
            });
          },
          error: (err: HttpErrorResponse) => {
            this.errorHandler.handleError(err);
            this.errorMessage = this.errorHandler.errorMessage;
          }
        });
    }
  }

  private getCategories = () => {
    this.repository.getData('api/categories')
      .subscribe({
        next: (categories: any[]|any) => this.categories = categories,
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  private getBrands = () => {
    this.repository.getData('api/brands')
      .subscribe({
        next: (brands: any[] |any) => this.brands = brands,
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  private getSuppliers = () => {
    this.repository.getData('api/suppliers')
      .subscribe({
        next: (suppliers: any[]|any) => this.suppliers = suppliers,
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  validateControl = (controlName: string) => {
    if (this.deviceForm.get(controlName).invalid && this.deviceForm.get(controlName).touched)
      return true;

    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.deviceForm.get(controlName).hasError(errorName))
      return true;

    return false;
  }

  updateDevice = (deviceFormValue: any) => {
    if (this.deviceForm.valid)
      this.executeDeviceUpdate(deviceFormValue);
  }

  private executeDeviceUpdate = (deviceFormValue: any) => {
    const updatedDevice: any = {
      id: this.deviceId ? this.deviceId : '',
      name: deviceFormValue.name,
      serialNumber: deviceFormValue.serialNumber,
      categoryId: deviceFormValue.categoryId,
      brandId: deviceFormValue.brandId,
      supplierId: deviceFormValue.supplierId,
      isFaulty: deviceFormValue.isFaulty
    };

    const apiUrl = `api/devices/${this.deviceId}`;
    this.repository.update(apiUrl, updatedDevice)
      .subscribe({
        next: () => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Device: ${updatedDevice.name} updated successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToDeviceList());
        },
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  redirectToDeviceList = () => {
    this.router.navigate(['/ui-components/faulty-device']);
  }

}
