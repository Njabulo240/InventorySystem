import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { UserRoleDto } from 'src/app/_interface/user';
import { ToastrService } from 'ngx-toastr';
import { UpdateRoleComponent } from './update-role/update-role.component';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { AddRoleComponent } from './add-role/add-role.component';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html'
})
export class RolesComponent implements OnInit {

  displayedColumns: string[] = ['action', 'role', 'date'];
  public dataSource = new MatTableDataSource<UserRoleDto>();
  private refreshSubscription!: Subscription;

  constructor(    
    private repoService: RepositoryService,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private dataService: DataService,
    private dialogserve: DialogService,) { 
      this.refreshSubscription = this.dataService.refreshTab1$.subscribe(() => {
        this.getRoles();
      });
    }
    ngOnInit(): void {
      this.getRoles();
    }
  
    public getRoles(){
      this.repoService.getData('api/roles')
      .subscribe(res => {
        this.dataSource.data = res as UserRoleDto[];
        
      },
      (err) => {
        console.log(err);
      })
    }

    addRole() {
      const popup = this.dialog.open(AddRoleComponent, {
        width: '500px', height: '232px',
        enterAnimationDuration: '100ms',
        exitAnimationDuration: '100ms',
      });
    }
    UpdateRole(id:string) {
      const popup = this.dialog.open(UpdateRoleComponent, {
        width: '500px', height: '232px',
        enterAnimationDuration: '100ms',
        exitAnimationDuration: '100ms',
        data:{
          id:id
         }
      });
    }

    DeleteRole(id: any) {
      this.dialogserve.openConfirmDialog('Are you sure, you want to delete the role ?')
        .afterClosed()
        .subscribe(   (res) => {
          if (res) {
            const deleteUri: string = `api/roles/${id}`;
            this.repoService.delete(deleteUri).subscribe((res) => {
              this.dialogserve.openSuccessDialog("The role has been deleted successfully.")
              .afterClosed()
              .subscribe((res) => {
                this.getRoles();
              });
            });
          }
        });
    }

}
