import { Component, OnInit, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ClubService } from '../../core/services/club.service';
import { Observable } from 'rxjs';
import { Club } from '../../shared/models/club.model';
import { AppConfig } from '../../app.config';
import { SubSink } from 'subsink';

@Component({
  selector: 'fws-history-container',
  templateUrl: './history-container.component.html',
  styleUrls: ['./history-container.component.css'],
})
export class HistoryContainerComponent implements OnInit, OnDestroy {
  constructor(private titleService: Title, private service: ClubService) {}

  private subs: SubSink = new SubSink();

  clubHistory: Club;
  loading: boolean;

  public ngOnInit() {
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Club'
    );

    this.loading = true;
    this.subs.sink = this.service.getClub().subscribe((res) => {
      this.clubHistory = res;
      this.loading = false;
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
