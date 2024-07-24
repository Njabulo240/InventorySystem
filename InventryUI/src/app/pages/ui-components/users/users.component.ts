import {
  AfterViewInit,
  Component,
  OnInit,
  ViewChild,
  inject,
} from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { UserDto } from 'src/app/_interface/user/userForRegistrationDto.model';
import { ErrorModalComponent } from 'src/app/shared/modals/error-modal/error-modal.component';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit, AfterViewInit {
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  public displayedColumns = [
    'userName',
    'firstName',
    'lastName',
    'email',
    'update',
    'delete',
  ];
  public dataSource = new MatTableDataSource<UserDto>();

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

  ngOnInit(): void {
    this.getAllUsers();
  }

  public getAllUsers = () => {
    this.repoService.getData('api/accounts').subscribe({
      next: (data: UserDto[] | any) => {
        this.dataSource.data = data;
      },
      error: (error: HttpErrorResponse) => {
        this.errorService.handleError(error);
        this.errorMessage = this.errorService.errorMessage;
      },
    });
  };

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  };

  public redirectToUpdate = (id: string) => {
    this.router.navigate([`/ui-components/update-user/${id}`]);
  };

  public deleteUser = (id: string) => {
    if (this.authService.isUserAdmin()) {
      this.dialogserve
        .openConfirmDialog('Are you sure you want to delete this user?')
        .afterClosed()
        .subscribe((res) => {
          if (res) {
            const deleteUri: string = `api/accounts/${id}`;
            this.repoService.delete(deleteUri).subscribe({
              next: () => {
                const config: ModalOptions = {
                  initialState: {
                    modalHeaderText: 'Success Message',
                    modalBodyText: 'User deleted successfully',
                    okButtonText: 'OK',
                  },
                };

                this.bsModalRef = this.modal.show(
                  SuccessModalComponent,
                  config
                );
                this.bsModalRef.content.redirectOnOk.subscribe(() =>
                  this.getAllUsers()
                );
              },
              error: (error: HttpErrorResponse) => {
                this.errorService.handleError(error);
                this.errorMessage = this.errorService.errorMessage;
              },
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
  };
}
