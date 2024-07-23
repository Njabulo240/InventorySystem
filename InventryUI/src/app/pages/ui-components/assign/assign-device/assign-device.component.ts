import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-assign-device',
  templateUrl: './assign-device.component.html',
  styleUrls: ['./assign-device.component.css']
})
export class AssignDeviceComponent implements OnInit {

  public deviceAssignmentForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  public devices: any[] = [];
  public filteredDevices: any[] = [];
  public employees: any[] = [];
  public filteredEmployees: any[] = [];
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
      employeeId: ['', Validators.required],
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

    this.repository.getData('api/employees')
      .subscribe(res => {
        this.employees = res as any[];
        this.filteredEmployees = this.employees;
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
      employeeId: deviceAssignmentFormValue.employeeId
    };

    const apiUrl = 'api/deviceassignments';
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

  onEmployeeSearch(searchTerm: string) {
    if (!searchTerm) {
      this.filteredEmployees = this.employees;
    } else {
      this.filteredEmployees = this.employees.filter(employee =>
        employee.firstName.toLowerCase().includes(searchTerm.toLowerCase())
      );
    }
  }
}
