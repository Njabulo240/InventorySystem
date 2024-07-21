import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangePasswordDto } from 'src/app/_interface/resetPassword/resetPasswordDto.model';
import { PasswordConfirmationValidatorService } from 'src/app/core/password-confirmation-validator.service';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { DialogService } from 'src/app/shared/services/dialog.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html'
})
export class ChangePasswordComponent implements OnInit {
  showSuccess: boolean;
  showError: boolean;
  errorMessage: string;
  passwordForm: FormGroup |any;
  result: any;
  hidePassword = true;
  
  constructor(private authService: AuthenticationService, 
    private passConfValidator: PasswordConfirmationValidatorService, 
    private route: ActivatedRoute, private router: Router,
    private dialogserve: DialogService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private Ref: MatDialogRef<ChangePasswordComponent> ,
  ) { }
  
    ngOnInit(): void {
      this.passwordForm = new FormGroup({
        previous: new FormControl('', [Validators.required]),
        password: new FormControl('', [Validators.required]),
        confirm: new FormControl('', [Validators.required]),
    });
    
    this.passwordForm.get('confirm').setValidators([Validators.required,
    this.passConfValidator.validateConfirmPassword(this.passwordForm.get('password'))]);
    this.result = this.data;
  }


  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }
  
  public validateControl = (controlName: string) => {
    return this.passwordForm.get(controlName).invalid && this.passwordForm.get(controlName).touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.passwordForm.get(controlName).hasError(errorName)
  }
  public resetPassword = (passwordFormValue:any) => {
    const changePass = { ... passwordFormValue };
    let email = this.result.email;
    const changePassDto: ChangePasswordDto = {
      previousPassword: changePass.previous,
      password: changePass.password,
      confirmPassword: changePass.confirm,
      email: email
    }
    this.authService.changePassword('api/authentication/ChangePassword', changePassDto)
    .subscribe({
      next: (_) => {
        this.logout();
   
    },
    error: (err: HttpErrorResponse) => {
      this.showError = true;
      this.errorMessage = err.message;
    }})
  }

  public logout = () => {
    this.Ref.close([]);
    this.authService.logout();
    this.router.navigate(["/authentication/login"]);
  }

  closeModal(){
    this.Ref.close([]);
  }
}
