import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-office-details',
  templateUrl: './office-details.component.html',
  styleUrls: ['./office-details.component.css']
})
export class OfficeDetailsComponent implements OnInit {

  public bsModalRef?: BsModalRef;
  public officeDetails: any;
  public errorMessage: string = '';
  public displayedColumns: string[] = ['serialNumber', 'categoryName', 'brandName', 'name', 'assignedDate'];
  public dataSource = new MatTableDataSource<any>();

  constructor(
    private route: ActivatedRoute,
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private dialogService: DialogService,
    private modal: BsModalService
  ) { }

  ngOnInit(): void {
    this.loadOfficeDetails();
  }

  private loadOfficeDetails(): void {
    const officeId = this.route.snapshot.paramMap.get('id');
    const apiUrl = `api/offices/${officeId}`;
    this.repository.getData(apiUrl)
      .subscribe({
        next: (office: any) => {
          this.officeDetails = office;
          this.dataSource.data = office.deviceAssignments;
        },
        error: (err: any) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  public deleteOffice(id: string) {
    this.dialogService.openConfirmDialog('Are you sure you want to delete this office?')
      .afterClosed()
      .subscribe(res => {
        if (res) {
          const deleteUri: string = `api/offices/${id}`;
          this.repository.delete(deleteUri).subscribe(() => {
            const config: ModalOptions = {
              initialState: {
                modalHeaderText: 'Success Message',
                modalBodyText: `Office deleted successfully`,
                okButtonText: 'OK'
              }
            };

            this.bsModalRef = this.modal.show(SuccessModalComponent, config);
            this.bsModalRef.content.redirectOnOk.subscribe(() => this.loadOfficeDetails());
          });
        }
      });
  }

}
