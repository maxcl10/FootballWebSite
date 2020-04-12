import { Component, OnInit, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { StatsService } from '../../core/services/stats.service';
import { Observable } from 'rxjs';
import { Stricker } from '../../shared/models/stricker.model';
import { AppConfig } from '../../app.config';
import { SubSink } from 'subsink';

@Component({
  selector: 'fws-stats-container',
  templateUrl: './stats-container.component.html',
  styleUrls: ['./stats-container.component.css'],
})
export class StatsContainerComponent implements OnInit, OnDestroy {
  constructor(private titleService: Title, private service: StatsService) {}

  private subs = new SubSink();

  public playerStats: Stricker[];
  public concededGoalsPerGame: number;
  public scoredGoalsPerGame: number;
  public shape: string[];

  loadingPlayerStats: boolean;

  ngOnInit() {
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Classement'
    );

    this.loadingPlayerStats = true;
    this.subs.sink = this.service.getStrickers().subscribe((res) => {
      this.playerStats = res;
      this.loadingPlayerStats = false;
    });

    this.subs.sink = this.service.getScoredGoalsPerGame().subscribe((res) => {
      this.scoredGoalsPerGame = res;
    });
    this.subs.sink = this.service.getConcededGoalsPerGame().subscribe((res) => {
      this.concededGoalsPerGame = res;
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
