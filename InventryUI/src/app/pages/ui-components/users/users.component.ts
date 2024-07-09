
import { AfterViewInit, Component, OnInit, ViewChild, inject } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UserDto } from 'src/app/_interface/user';
import { AddUserComponent } from './add-user/add-user.component';
import { MatDialog } from '@angular/material/dialog';
import { UpdateUserComponent } from './update-user/update-user.component';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit, AfterViewInit{

  displayedColumns: string[] = ['action', 'username', 'name', 'surname','roles','email','emailconfirm'];
  public dataSource = new MatTableDataSource<UserDto>();

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  private refreshSubscription!: Subscription;
  constructor(    
    private repoService: RepositoryService,
    private dialog: MatDialog,
    private dialogserve: DialogService,
    private dataService: DataService,) {
      this.refreshSubscription = this.dataService.refreshTab1$.subscribe(() => {
        this.getUsers();
      });
    }
    
    ngOnInit(): void {
      this.getUsers();
    }
  
    public getUsers(){
      this.repoService.getData('api/users')
      .subscribe(res => {
        this.dataSource.data = res as UserDto[]; 
      },
      (err) => {
       console.log(err)
      })
    }


    addUser() {
      const popup = this.dialog.open(AddUserComponent, {
        width: '500px', height: '570px',
        enterAnimationDuration: '100ms',
        exitAnimationDuration: '100ms',
      });
    }

    updateUser(id: string) {
      const popup = this.dialog.open(UpdateUserComponent, {
        width: '500px', height: '567px',
        enterAnimationDuration: '100ms',
        exitAnimationDuration: '100ms',
        data:{
          id:id
         }
      });
    }


    DeleteUser(id: any) {
      this.dialogserve.openConfirmDialog('Are you sure, you want to delete the user ?')
        .afterClosed()
        .subscribe(   (res) => {
          if (res) {
            const deleteUri: string = `api/users/${id}`;
            this.repoService.delete(deleteUri).subscribe((res) => {
              this.dialogserve.openSuccessDialog("The user has been deleted successfully.")
              .afterClosed()
              .subscribe((res) => {
                this.getUsers();
              });
            });
          }
        });
    }


    ngAfterViewInit(): void {
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    }
    public doFilter = (value: string) => {
      this.dataSource.filter = value.trim().toLocaleLowerCase();
    }
}
