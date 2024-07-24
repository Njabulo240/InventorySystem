import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { UserForRegistrationDto } from 'src/app/_interface/user/userForRegistrationDto.model';
import { PasswordConfirmationValidatorService } from 'src/app/core/password-confirmation-validator.service';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';

import { AuthenticationService } from 'src/app/shared/services/authentication.service';


@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',

})
export class AddUserComponent implements OnInit {
  registerForm: FormGroup | any;
  errorMessage: string = '';
  showError: boolean;
  public bsModalRef?: BsModalRef;

  constructor(private authService: AuthenticationService, 
    private passConfValidator: PasswordConfirmationValidatorService, private router: Router,
    private modal: BsModalService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });
    this.registerForm.get('confirm').setValidators([Validators.required, 
    this.passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
  }

  public validateControl = (controlName: string) => {
    return this.registerForm.get(controlName).invalid && this.registerForm.get(controlName).touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.get(controlName).hasError(errorName)
  }

  public registerUser = (registerFormValue:any) => {
    this.showError = false;
    const formValues = { ...registerFormValue };

    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      userName: formValues.email,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm
    };

    this.authService.registerUser("api/accounts/registration", user)
    .subscribe({
      next: (response: any) => {
        const config: ModalOptions = {
          initialState: {
            modalHeaderText: 'Success Message',
            modalBodyText: `user created successfully`,
            okButtonText: 'OK'
          }
        };

        this.bsModalRef = this.modal.show(SuccessModalComponent, config);
        this.bsModalRef.content.redirectOnOk.subscribe((_: any) => this.redirectToUser());
      },
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
        this.showError = true;
      }
    })
  }

  redirectToUser = () => {
    this.router.navigate(['/ui-components/user']);
  }
}
