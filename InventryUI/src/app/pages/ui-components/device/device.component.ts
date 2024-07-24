import { HttpErrorResponse } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Brand } from 'src/app/_interface/inventory/brand';
import { Category } from 'src/app/_interface/inventory/category';
import { Device } from 'src/app/_interface/inventory/device';
import { Supplier } from 'src/app/_interface/inventory/supplier';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.css']
})
export class DeviceComponent implements OnInit,AfterViewInit {
  public categories: Category[] = [];
  public brands: Brand[] = [];
  public suppliers: Supplier[] = [];
  public filterForm: FormGroup;
  public errorMessage: string = '';
  public displayedColumns = ['name', 'serialNumber', 'categoryName', 'brandName', 'supplierName', 'isFaulty', 'actions'];
  public dataSource = new MatTableDataSource<Device>();
  private allDevices: Device[] = [];
  public bsModalRef?: BsModalRef;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private repoService: RepositoryService,
    private fb: FormBuilder,
    private errorService: RepositoryErrorHandlerService,
    private dialogService: DialogService,
    private modal: BsModalService,
    private router: Router
  ) { }

  ngOnInit() {
    this.filterForm = this.fb.group({
      category: [''],
      brand: [''],
      supplier: ['']
    });

    this.loadDropdownData();
    this.getAllDevices();
    
    this.filterForm.valueChanges.subscribe(() => {
      this.applyFilter();
    });
  }

  private loadDropdownData = () => {
    this.repoService.getData('api/categories').subscribe(
      res => this.categories = res as Category[]
    );

    this.repoService.getData('api/brands').subscribe(
      res => this.brands = res as Brand[]
    );

    this.repoService.getData('api/suppliers').subscribe(
      res => this.suppliers = res as Supplier[]
    );
  }

  private getAllDevices() {
    this.repoService.getData('api/devices').subscribe(
      res => {
        this.allDevices = res as Device[];
        this.dataSource.data = this.allDevices;
        this.applyFilter();
      },
      error => {
        this.errorMessage = 'Failed to load devices. Please try again later.';
        console.error('Error fetching devices:', error);
      }
    );
  }

  private applyFilter() {
    const filters = this.filterForm.value;

    // Filter devices based on selected filters
    const filteredDevices = this.allDevices.filter(device => {
      const matchesCategory = !filters.category || device.categoryName === filters.category;
      const matchesBrand = !filters.brand || device.brandName === filters.brand;
      const matchesSupplier = !filters.supplier || device.supplierName === filters.supplier;

      return matchesCategory && matchesBrand && matchesSupplier;
    });

    this.dataSource.data = filteredDevices;

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public doFilter(value: string) {
    this.dataSource.filter = value.trim().toLowerCase();
  }

  public redirectToUpdate(id: string) {
   this.router.navigate([`/ui-components/update-device/${id}`]);
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public deleteDevice = (id: string) => {
    this.dialogService.openConfirmDialog('Are you sure you want to delete this device?')
      .afterClosed()
      .subscribe(res => {
        if (res) {
          this.repoService.delete(`api/devices/${id}`).subscribe(() => {
            const config: ModalOptions = {
              initialState: {
                modalHeaderText: 'Success Message',
                modalBodyText: `Device deleted successfully`,
                okButtonText: 'OK'
              }
            };

            this.bsModalRef = this.modal.show(SuccessModalComponent, config);
            this.bsModalRef.content.redirectOnOk.subscribe(() => 
              this.getAllDevices()
            
            );
          });
        }
      });
  }
}
