import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../core/services/authentication.service';
import { User } from '../../shared/models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'fws-login-container',
  templateUrl: './login-container.component.html',
  styleUrls: ['./login-container.component.css'],
})
export class LoginContainerComponent {
  public user = new User();
  public errorMessage = '';

  constructor(private service: AuthenticationService, private router: Router) {}

  public login() {
    this.service.authenticate(this.user.alias, this.user.password).subscribe(
      (result) => {
        if (result == null) {
          this.errorMessage = 'Failed to login';
        } else {
          sessionStorage.setItem('user', JSON.stringify(result));
          if (this.service.redirectUrl) {
            this.router.navigateByUrl(this.service.redirectUrl);
          } else {
            this.router.navigate(['/admin']);
          }
        }
      },
      (error) => {
        this.errorMessage = error;
      }
    );
  }

  public goBack() {
    window.history.back();
  }
}
