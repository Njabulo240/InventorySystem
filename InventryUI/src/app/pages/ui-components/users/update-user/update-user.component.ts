import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserRoleDto, UserForRegistrationDto } from 'src/app/_interface/user';
import { DataService } from 'src/app/shared/services/data.service';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
})
export class UpdateUserComponent implements OnInit {
  dataForm: FormGroup |any;
  roles:UserRoleDto []|any;
  selectedRoles: string[] = [];
  user:UserForRegistrationDto |any;
  private userId: string | null = '';

  constructor( 
    private repoService: RepositoryService,
    private dataService: DataService,
    private toastr: ToastrService,
    private dialogserve: DialogService,
    private route: ActivatedRoute) {}

  ngOnInit() {
    this.userId = this.route.snapshot.paramMap.get('id');
    this.dataForm = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      userName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      email: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });

    this.getRoles();
    this.getUsertoUpdate();
  }



  public validateControl = (controlName: string) => {
    return this.dataForm?.get(controlName)?.invalid && this.dataForm?.get(controlName)?.touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.dataForm?.get(controlName)?.hasError(errorName)
  }

  public createData = (dataFormValue: any) => {

    if (this.dataForm.valid) {
      this.executeDataCreation(dataFormValue);

    }
  };
  private executeDataCreation = (dataFormValue: any) => {
    let data: UserForRegistrationDto = {
   
      firstName: dataFormValue.firstName,
      lastName: dataFormValue.lastName,
      userName: dataFormValue.userName,
      email: dataFormValue.email,
      roles: this.selectedRoles,

    };
    const Uri: string = `api/accounts/${this.userId}`;
    this.repoService.update(Uri, data).subscribe(
      (res) => {

      },
      (error) => {
       // this.toastr.error(error);
      }
    );
  };

  public getRoles(){
    this.repoService.getData('api/roles')
    .subscribe(res => {
      this.roles = res as UserRoleDto[];
      
    },
    (err) => {
      this.toastr.error(err);
    })
  }


  toggleRoleSelection(event: any, roleName: string): void {
    if (event.checked) {
      this.selectedRoles.push(roleName);
    } else {
      this.selectedRoles = this.selectedRoles.filter(role => role !== roleName);
    }
  }

  private getUsertoUpdate = () => {

    const Uri: string = `api/accounts/${this.userId}`;
    console.log(Uri);
    this.repoService.getData(Uri)
      .subscribe({
        next: (own: any) => {
          this.user = { ...own };
          this.dataForm.patchValue(this.user);
          this.selectedRoles = this.user.roles; 
        },
        error: (err) => {
          //this.toastr.error(err);
        }
      })
  }

  isSelected(roleName: string): boolean {
    return this.selectedRoles.includes(roleName);
  }

}
