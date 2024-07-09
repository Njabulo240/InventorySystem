import {
  Component,
  Output,
  EventEmitter,
  Input,
  ViewEncapsulation,
  inject,
} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ChangePasswordComponent } from '../../../pages/authentication/change-password/change-password.component';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class HeaderComponent {
  @Input() showToggle = true;
  @Input() toggleChecked = false;
  @Output() toggleMobileNav = new EventEmitter<void>();
  @Output() toggleMobileFilterNav = new EventEmitter<void>();
  @Output() toggleCollapsed = new EventEmitter<void>();
  showFiller = false;
  email?: any
  userName?: any
  userRole?: any

  constructor(
    public dialog: MatDialog,
    private authService: AuthenticationService,
    private router: Router,
  ) {
  }
  ngOnInit(): void {
    this.authService.updateuser.subscribe((res) => {
      this.getUserEmail();
      this.getUserName();
      this.getUserRole();
    });
    this.getUserEmail();
    this.getUserName();
    this.getUserRole();
  }

  public getUserName() {
    this.userName = this.authService.loadCurrentUserName();
  }
  public getUserRole() {
    this.userRole = this.authService.loadCurrentUserRole();
  }

  public getUserEmail() {
    this.email = this.authService.loadCurrentUserEmail();
    console.log(this.email)
  }

  public logout = () => {
    this.authService.logout();
    this.router.navigate(["/authentication/login"]);
  }

  ChangePassword() {
    const popup = this.dialog.open(ChangePasswordComponent, {
      width: '500px', height: '510px',
      enterAnimationDuration: '100ms',
      exitAnimationDuration: '100ms',
      data: {
        email: this.email
      }
    });
  }


}
