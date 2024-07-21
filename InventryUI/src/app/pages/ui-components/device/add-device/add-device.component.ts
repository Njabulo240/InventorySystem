import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-add-device',
  templateUrl: './add-device.component.html',
  styleUrls: ['./add-device.component.css']
})
export class AddDeviceComponent implements OnInit {

  public deviceForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  public categories: any[] = [];
  public brands: any[] = [];
  public suppliers: any[] = [];

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService
  ) { }

  ngOnInit(): void {
    this.deviceForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      serialNumber: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      categoryId: new FormControl('', [Validators.required]),
      brandId: new FormControl('', [Validators.required]),
      supplierId: new FormControl('', [Validators.required]),
      isFaulty: new FormControl(false)
    });

    this.loadDropdownData();
  }

  private loadDropdownData() {
    this.repository.getData('api/categories')
      .subscribe(res => this.categories = res as any[], err => this.errorHandler.handleError(err));
    this.repository.getData('api/brands')
      .subscribe(res => this.brands = res as any[], err => this.errorHandler.handleError(err));
    this.repository.getData('api/suppliers')
      .subscribe(res => this.suppliers = res as any[], err => this.errorHandler.handleError(err));
  }

  validateControl(controlName: string): boolean {
    return this.deviceForm.get(controlName).invalid && this.deviceForm.get(controlName).touched;
  }

  hasError(controlName: string, errorName: string): boolean {
    return this.deviceForm.get(controlName).hasError(errorName);
  }

  createDevice(deviceFormValue: any): void {
    if (this.deviceForm.valid) {
      this.executeDeviceCreation(deviceFormValue);
    }
  }

  private executeDeviceCreation(deviceFormValue: any): void {
    const device = {
      name: deviceFormValue.name,
      serialNumber: deviceFormValue.serialNumber,
      categoryId: deviceFormValue.categoryId,
      brandId: deviceFormValue.brandId,
      supplierId: deviceFormValue.supplierId,
      isFaulty: deviceFormValue.isFaulty
    };
 console.log(device);
    const apiUrl = 'api/devices';
    this.repository.create(apiUrl, device)
      .subscribe({
        next: (createdDevice: any) => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Device: ${createdDevice.name} created successfully`,
              okButtonText: 'OK'
            }
          };
          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToDeviceList());
        },
        error: (err: any) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  redirectToDeviceList(): void {
    this.router.navigate(['/ui-components/device']);
  }

}
