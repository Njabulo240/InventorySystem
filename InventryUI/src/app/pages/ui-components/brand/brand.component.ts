import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Brand } from 'src/app/_interface/inventory/brand';
import { ErrorModalComponent } from 'src/app/shared/modals/error-modal/error-modal.component';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css'],
})
export class BrandComponent implements OnInit {
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  public displayedColumns = ['name', 'update', 'delete'];
  public dataSource = new MatTableDataSource<Brand>();

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private repoService: RepositoryService,
    private errorService: RepositoryErrorHandlerService,
    private router: Router,
    private dialogserve: DialogService,
    private modal: BsModalService,
    private authService: AuthenticationService
  ) {}

  ngOnInit() {
    this.getAllBrands();
  }

  public getAllBrands = () => {
    this.repoService.getData('api/brands').subscribe(
      (res) => {
        this.dataSource.data = res as Brand[];
      },
      (error: HttpErrorResponse) => {
        this.errorService.handleError(error);
      }
    );
  };

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  };

  public redirectToUpdate = (id: string) => {
    this.router.navigate([`/ui-components/update-brand/${id}`]);
  };

  DeleteBrand(id: any) {
    if (this.authService.isUserAdmin()) {
      this.dialogserve
        .openConfirmDialog('Are you sure, you want to delete the brand ?')
        .afterClosed()
        .subscribe((res) => {
          if (res) {
            const deleteUri: string = `api/brands/${id}`;
            this.repoService.delete(deleteUri).subscribe((res) => {
              const config: ModalOptions = {
                initialState: {
                  modalHeaderText: 'Success Message',
                  modalBodyText: `Brand created successfully`,
                  okButtonText: 'OK',
                },
              };

              this.bsModalRef = this.modal.show(SuccessModalComponent, config);
              this.bsModalRef.content.redirectOnOk.subscribe((_: any) =>
                this.getAllBrands()
              );
            });
          }
        });
    } else {
      const config: ModalOptions = {
        initialState: {
          modalHeaderText: 'Error Message',
          modalBodyText: 'Only Admin allowed',
          okButtonText: 'OK',
        },
      };
      this.modal.show(ErrorModalComponent, config);
    }
  }
}
