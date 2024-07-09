import { Routes } from '@angular/router';
import { AppSideLoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

export const AuthenticationRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'login',
        component: AppSideLoginComponent,
      },
      { 
        path: 'forgot-password', 
      component: ForgotPasswordComponent 
      },
      { 
        path: 'reset-password', 
        component: ResetPasswordComponent 
      }
    ],
  },
];
