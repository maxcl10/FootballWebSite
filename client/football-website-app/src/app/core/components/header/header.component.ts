import { Component, OnInit } from '@angular/core';
import { ClubService } from '../../services/club.service';
import { Club } from '../../../shared/models/club.model';

@Component({
  selector: 'fws-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  constructor(private clubService: ClubService) {}

  club: Club;
  errorMessage: string;

  ngOnInit(): void {
    this.clubService.getClub().subscribe(
      (club) => {
        this.club = club;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }
}
