import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Employee } from 'src/app/_interface/employee';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  public displayedColumns = ['firstName', 'lastName', 'employeeNumber', 'position', 'email','devices', 'update', 'delete'];
  public dataSource = new MatTableDataSource<Employee>();

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private repoService: RepositoryService,
    private errorService: RepositoryErrorHandlerService,
    private router: Router,
    private dialogService: DialogService,
    private modalService: BsModalService
  ) { }

  ngOnInit() {
    this.getAllEmployees();
  }

  public getAllEmployees = () => {
    this.repoService.getData('api/employees')
      .subscribe(
        res => {
          this.dataSource.data = res as Employee[];
        },
        (error: HttpErrorResponse) => {
          this.errorService.handleError(error);
        }
      );
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  public redirectToUpdate = (id: string) => {
    this.router.navigate([`/ui-components/update-employee/${id}`]);
  }

  public deleteEmployee(id: string) {
    this.dialogService.openConfirmDialog('Are you sure you want to delete this employee?')
      .afterClosed()
      .subscribe(res => {
        if (res) {
          const deleteUri: string = `api/employees/${id}`;
          this.repoService.delete(deleteUri).subscribe(() => {
            const config: ModalOptions = {
              initialState: {
                modalHeaderText: 'Success Message',
                modalBodyText: `Employee deleted successfully`,
                okButtonText: 'OK'
              }
            };

            this.bsModalRef = this.modalService.show(SuccessModalComponent, config);
            this.bsModalRef.content.redirectOnOk.subscribe(() => this.getAllEmployees());
          });
        }
      });
  }

}
