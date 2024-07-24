import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ErrorModalComponent } from 'src/app/shared/modals/error-modal/error-modal.component';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css'],
})
export class EmployeeDetailsComponent implements OnInit {
  public bsModalRef?: BsModalRef;
  public employeeDetails: any;
  public errorMessage: string = '';
  public displayedColumns: string[] = [
    'serialNumber',
    'categoryName',
    'brandName',
    'name',
    'assignedDate',
    'delete',
  ];
  public dataSource = new MatTableDataSource<any>();

  constructor(
    private route: ActivatedRoute,
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private dialogService: DialogService,
    private modal: BsModalService,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.loadEmployeeDetails();
  }

  private loadEmployeeDetails(): void {
    const employeeId = this.route.snapshot.paramMap.get('id');
    const apiUrl = `api/employees/${employeeId}`;
    this.repository.getData(apiUrl).subscribe({
      next: (employee: any) => {
        this.employeeDetails = employee;
        this.dataSource.data = employee.deviceAssignments;
      },
      error: (err: any) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      },
    });
  }

  public deleteAssignDevice(id: string) {
    if (this.authService.isUserAdmin()) {
      this.dialogService
        .openConfirmDialog('Are you sure you want to remove this device?')
        .afterClosed()
        .subscribe((res) => {
          if (res) {
            const deleteUri: string = `api/deviceassignments/${id}`;
            this.repository.delete(deleteUri).subscribe(() => {
              const config: ModalOptions = {
                initialState: {
                  modalHeaderText: 'Success Message',
                  modalBodyText: `Device remove successfully`,
                  okButtonText: 'OK',
                },
              };

              this.bsModalRef = this.modal.show(SuccessModalComponent, config);
              this.bsModalRef.content.redirectOnOk.subscribe(() =>
                this.loadEmployeeDetails()
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
