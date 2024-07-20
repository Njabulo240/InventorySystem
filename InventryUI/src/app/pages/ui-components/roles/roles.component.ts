
import { Component, OnInit, ViewChild, inject } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Role } from 'src/app/_interface/role.model';
import { HttpErrorResponse } from '@angular/common/http';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html'
})
export class RolesComponent implements OnInit {

  public displayedColumns = ['name', 'dateCreated', 'update', 'delete'];
  public dataSource = new MatTableDataSource<Role>();

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private repoService: RepositoryService, private errorService: RepositoryErrorHandlerService, private router: Router) { }

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
}
