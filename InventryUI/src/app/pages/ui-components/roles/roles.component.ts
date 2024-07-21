
import { Component, OnInit, ViewChild, inject } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Role } from 'src/app/_interface/role.model';
import { HttpErrorResponse } from '@angular/common/http';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html'
})
export class RolesComponent implements OnInit {
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  public displayedColumns = ['name', 'dateCreated', 'update', 'delete'];
  public dataSource = new MatTableDataSource<Role>();

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    private repoService: RepositoryService,
    private errorService: RepositoryErrorHandlerService,
    private router: Router,
    private dialogserve: DialogService,
    private modal: BsModalService
  ) { }
  ngOnInit() {
    this.getAllRoles();
  }

  public getAllRoles = () => {
    this.repoService.getData('api/roles')
      .subscribe(res => {
        this.dataSource.data = res as Role[];
      },
      (error:HttpErrorResponse) => {
       this.errorService.handleError(error);
      });
  }


  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  public redirectToUpdate = (id: string) => {
    this.router.navigate([`/role/update/${id}`]);
  }

  public redirectToDelete = (id: string) => {
    this.router.navigate([`/role/delete/${id}`]);
  }

  public deleteRole = (id: string) => {
    this.dialogserve.openConfirmDialog('Are you sure you want to delete this role?')
      .afterClosed()
      .subscribe(res => {
        if (res) {
          const deleteUri: string = `api/roles/${id}`;
          this.repoService.delete(deleteUri)
            .subscribe({
              next: () => {
                const config: ModalOptions = {
                  initialState: {
                    modalHeaderText: 'Success Message',
                    modalBodyText: 'Role deleted successfully',
                    okButtonText: 'OK'
                  }
                };

                this.bsModalRef = this.modal.show(SuccessModalComponent, config);
                this.bsModalRef.content.redirectOnOk.subscribe(() => this.getAllRoles());
              },
              error: (error: HttpErrorResponse) => {
                this.errorService.handleError(error);
                this.errorMessage = this.errorService.errorMessage;
              }
            });
        }
      });
  }
}
