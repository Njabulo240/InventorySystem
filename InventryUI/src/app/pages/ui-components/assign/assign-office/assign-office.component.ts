import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-assign-office',
  templateUrl: './assign-office.component.html',
  styleUrls: ['./assign-office.component.css']
})
export class AssignOfficeComponent implements OnInit {

  public deviceAssignmentForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  public devices: any[] = [];
  public filteredDevices: any[] = [];
  public offices: any[] = [];
  public filteredoffices: any[] = [];
  public categories: any[] = [];
  public brands: any[] = [];

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.deviceAssignmentForm = this.fb.group({
      deviceId: ['', Validators.required],
      officeId: ['', Validators.required],
      category: [''],
      brand: ['']
    });

    this.loadDropdownData();

    this.deviceAssignmentForm.get('category').valueChanges.subscribe(() => {
      this.applyFilter();
    });

    this.deviceAssignmentForm.get('brand').valueChanges.subscribe(() => {
      this.applyFilter();
    });
  }

  private loadDropdownData() {
    this.repository.getData('api/devices/available')
      .subscribe(res => {
        this.devices = res as any[];
        this.filteredDevices = this.devices;
      }, err => this.errorHandler.handleError(err));

    this.repository.getData('api/offices')
      .subscribe(res => {
        this.offices = res as any[];
        this.filteredoffices = this.offices;
      }, err => this.errorHandler.handleError(err));
      

    this.repository.getData('api/categories')
      .subscribe(res => this.categories = res as any[], err => this.errorHandler.handleError(err));

    this.repository.getData('api/brands')
      .subscribe(res => this.brands = res as any[], err => this.errorHandler.handleError(err));
  }

  validateControl(controlName: string): boolean {
    return this.deviceAssignmentForm.get(controlName).invalid && this.deviceAssignmentForm.get(controlName).touched;
  }

  hasError(controlName: string, errorName: string): boolean {
    return this.deviceAssignmentForm.get(controlName).hasError(errorName);
  }

  createDeviceAssignment(deviceAssignmentFormValue: any): void {
    if (this.deviceAssignmentForm.valid) {
      this.executeDeviceAssignmentCreation(deviceAssignmentFormValue);
    }
  }

  private executeDeviceAssignmentCreation(deviceAssignmentFormValue: any): void {
    const deviceAssignment = {
      deviceId: deviceAssignmentFormValue.deviceId,
      officeId: deviceAssignmentFormValue.officeId
    };

    const apiUrl = 'api/deviceassignments/office';
    this.repository.create(apiUrl, deviceAssignment)
      .subscribe({
        next: (createdDeviceAssignment: any) => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Device Assigned successfully`,
              okButtonText: 'OK'
            }
          };
          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToDeviceAssignmentList());
        },
        error: (err: any) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }


  redirectToDeviceAssignmentList(): void {
    this.loadDropdownData();
    this.deviceAssignmentForm.get('category').valueChanges.subscribe(() => {
      this.applyFilter();
    });

    this.deviceAssignmentForm.get('brand').valueChanges.subscribe(() => {
      this.applyFilter();
    });
  }

  private applyFilter() {
    const selectedCategory = this.deviceAssignmentForm.get('category').value;
    const selectedBrand = this.deviceAssignmentForm.get('brand').value;

    this.filteredDevices = this.devices.filter(device => {
      const matchesCategory = !selectedCategory || device.categoryName === selectedCategory;
      const matchesBrand = !selectedBrand || device.brandName === selectedBrand;

      return matchesCategory && matchesBrand;
    });
  }

  onOfficeSearch(searchTerm: string) {
    if (!searchTerm) {
      this.filteredoffices = this.offices;
    } else {
      this.filteredoffices = this.offices.filter(office =>
        office.firstName.toLowerCase().includes(searchTerm.toLowerCase())
      );
    }
  }

}
