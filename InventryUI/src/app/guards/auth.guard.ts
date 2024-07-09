import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthenticationService } from '../shared/services/authentication.service';



@Injectable({
  providedIn: 'root'
})
export class AuthGuard  {

  constructor(private authService: AuthenticationService, private router: Router){}
  
  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) { 
    if (this.authService.isUserAuthenticated()) {
      return true;
    }
    this.router.navigate(['/authentication/login'], { queryParams: { returnUrl: state.url }});
    
    return false;
  } 
  
}
