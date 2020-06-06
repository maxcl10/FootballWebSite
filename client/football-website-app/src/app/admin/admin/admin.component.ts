import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../core/services/authentication.service';
import { User } from '../../shared/models/user.model';

@Component({
  selector: 'fws-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent implements OnInit {
  public errorMessage: string;

  user: User;
  constructor(private authenticationService: AuthenticationService) {
    this.user = this.authenticationService.getLoggedUser();
  }

  public ngOnInit() {}

  public _toggleSidebar() {
    // $('#wrapper').toggleClass('toggled');
  }
}
