import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthResponseDto } from 'src/app/_interface/response/authResponseDto.model';
import { UserForAuthenticationDto } from 'src/app/_interface/user/userForAuthenticationDto.model';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class AppSideLoginComponent {
  private returnUrl: string;

  loginForm: FormGroup | any;
  errorMessage: string = '';
  showError: boolean;
  hidePassword = true;

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl("njebzeliny@gmail.com", [Validators.required]),
      password: new FormControl("AdminPassword123", [Validators.required])
    })
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  validateControl = (controlName: string) => {
    return this.loginForm.get(controlName).invalid && this.loginForm.get(controlName).touched
  }

  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName).hasError(errorName)
  }

  loginUser = (loginFormValue:any) => {
    this.showError = false;
    const login = { ...loginFormValue };

    const userForAuth: UserForAuthenticationDto = {
      email: login.username,
      password: login.password,
      clientURI: 'http://localhost:4200/authentication/forgotpassword'
    }

    this.authService.loginUser('api/accounts/login', userForAuth)
      .subscribe({
        next: (res: AuthResponseDto) => {
            localStorage.setItem("token", res.token);
            this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
            this.router.navigate([this.returnUrl]);
          
        },
        error: (err: HttpErrorResponse) => {
          this.errorMessage = err.message;
          this.showError = true;
        }
      })
  }

}
