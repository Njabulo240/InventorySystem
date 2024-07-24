import { HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { AuthResponseDto } from 'src/app/_interface/response/authResponseDto.model';
import { ForgotPasswordDto } from 'src/app/_interface/resetPassword/forgotPasswordDto.model';
import { ChangePasswordDto, ResetPasswordDto } from 'src/app/_interface/resetPassword/resetPasswordDto.model';
import { RegistrationResponseDto } from 'src/app/_interface/response/registrationResponseDto.model';
import { UserForAuthenticationDto } from 'src/app/_interface/user/userForAuthenticationDto.model';
import { UserForRegistrationDto } from 'src/app/_interface/user/userForRegistrationDto.model';




@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private authChangeSub = new Subject<boolean>()
  public authChanged = this.authChangeSub.asObservable();
  private _updateuser = new Subject<void>();

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

  get updateuser() {
    return this._updateuser;
  }
  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto>(this.createCompleteRoute(route, environment.apiUrl), body);
  }

  public loginUser = (route: string, body: UserForAuthenticationDto) => {
    return this.http.post<AuthResponseDto>(this.createCompleteRoute(route, environment.apiUrl), body);
  }

  public forgotPassword = (route: string, body: ForgotPasswordDto) => {
    return this.http.post(this.createCompleteRoute(route, environment.apiUrl), body);
  }

  public resetPassword = (route: string, body: ResetPasswordDto) => {
    return this.http.post(this.createCompleteRoute(route, environment.apiUrl), body);
  }

  public changePassword = (route: string, body: ChangePasswordDto) => {
    return this.http.post(this.createCompleteRoute(route, environment.apiUrl), body);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  public isUserAuthenticated = (): boolean |any => {
    const token = localStorage.getItem("token");
 
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  public isUserAdmin = (): boolean => {
    const token: any = localStorage.getItem("token");
    const decodedToken = this.jwtHelper.decodeToken(token);
    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    return role === 'Admin';
  }

  public loadCurrentUserEmail() {
    const token: any = localStorage.getItem("token");
    const decodedToken = this.jwtHelper.decodeToken(token);
    const name = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    return name;
  }
  public loadCurrentUserName() {
    const token: any = localStorage.getItem("token");
    const decodedToken = this.jwtHelper.decodeToken(token);
    const name = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    return name;
  }

  public loadCurrentUserRole() {
    const token: any = localStorage.getItem("token");
    const decodedToken = this.jwtHelper.decodeToken(token);
    const name = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    return name;
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
