import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-user-role',
  templateUrl: './update-user-role.component.html',
  styleUrls: ['./update-user-role.component.css']
})
export class UpdateUserRoleComponent implements OnInit {

  public userRoleForm: FormGroup;
  public roles: any[] = []; // Replace 'any' with the specific role type if you have one
  public selectedRoles: Set<string> = new Set(); // Track selected roles
  public errorMessage: string = '';
  private userId: string | null = '';

  constructor(
    private repository: RepositoryService,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.userId = this.route.snapshot.paramMap.get('userId');
    this.userRoleForm = new FormGroup({});

    this.loadRoles(); // Fetch all roles
    this.initializeForm(); // Fetch user roles and initialize the form
  }

  private loadRoles = () => {
    this.repository.getData('api/roles') // Endpoint to get all roles
      .subscribe({
        next: (roles: any) => {
          this.roles = roles; // Assuming 'roles' is an array of role objects
        },
        error: (err: HttpErrorResponse) => {
          this.errorMessage = 'Error fetching roles';
        }
      });
  }

  private initializeForm = () => {
    if (this.userId) {
      this.repository.getData(`api/account/users/${this.userId}/roles`) // Fetch user with roles
        .subscribe({
          next: (userWithRoles: any) => {
            // Assuming userWithRoles.roles contains an array of role names
            this.selectedRoles = new Set(userWithRoles.roles || []);
          },
          error: (err: HttpErrorResponse) => {
            this.errorMessage = 'Error fetching user roles';
          }
        });
    }
  }

  public isSelected = (roleName: string): boolean => {
    return this.selectedRoles.has(roleName);
  }

  public toggleRoleSelection = (event: any, roleName: string) => {
    if (event.checked) {
      this.selectedRoles.add(roleName);
    } else {
      this.selectedRoles.delete(roleName);
    }
  }

  public updateUserRole = () => {
    if (this.userId) {
      const apiUrl = `api/account/users/${this.userId}/roles`;
      this.repository.update(apiUrl, Array.from(this.selectedRoles))
        .subscribe({
          next: () => {
            this.snackBar.open('User roles updated successfully', 'Close', {
              duration: 2000
            });
            this.router.navigate(['/user-list']); // Redirect to user list or another appropriate page
          },
          error: (err: HttpErrorResponse) => {
            this.errorMessage = 'Error updating user roles';
          }
        });
    }
  }

  private redirectToUserList = () => {
    this.router.navigate(['/user-list']); // Adjust to your specific route
  }
}
