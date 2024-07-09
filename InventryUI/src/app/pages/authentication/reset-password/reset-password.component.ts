import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute} from '@angular/router';
import { ResetPasswordDto } from 'src/app/_interface/resetPassword/resetPasswordDto.model';
import { PasswordConfirmationValidatorService } from 'src/app/core/password-confirmation-validator.service';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';


@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
})
export class ResetPasswordComponent implements OnInit {
  resetPasswordForm: FormGroup |any;
  showSuccess: boolean;
  showError: boolean;
  errorMessage: string;
  hidePassword = true;

  private token: string;
  private email: string;

  constructor(private authService: AuthenticationService, private passConfValidator: PasswordConfirmationValidatorService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.resetPasswordForm = new FormGroup({
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });

    this.resetPasswordForm.get('confirm').setValidators([Validators.required,
    this.passConfValidator.validateConfirmPassword(this.resetPasswordForm.get('password'))]);

    this.token = this.route.snapshot.queryParams['token'];
    this.email = this.route.snapshot.queryParams['email'];
  }
  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }
  public validateControl = (controlName: string) => {
    return this.resetPasswordForm.get(controlName).invalid && this.resetPasswordForm.get(controlName).touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.resetPasswordForm.get(controlName).hasError(errorName)
  }

  public resetPassword = (resetPasswordFormValue:any) => {
    this.showError = this.showSuccess = false;
    const resetPass = { ...resetPasswordFormValue };

    const resetPassDto: ResetPasswordDto = {
      password: resetPass.password,
      confirmPassword: resetPass.confirm,
      token: this.token,
      email: this.email
    }

    this.authService.resetPassword('api/accounts/resetpassword', resetPassDto)
      .subscribe({
        next: (_) => this.showSuccess = true,
        error: (err: HttpErrorResponse) => {
          this.showError = true;
          this.errorMessage = err.message;
        }
      })
  }
}
