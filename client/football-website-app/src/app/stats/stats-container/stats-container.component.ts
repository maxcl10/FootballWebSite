import { Component, OnInit, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { StatsService } from '../../core/services/stats.service';
import { Observable } from 'rxjs';
import { PlayerStats } from '../../shared/models/stricker.model';
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

  public playerStats: PlayerStats[];
  public concededGoalsPerGame: number;
  public scoredGoalsPerGame: number;
  public shape: string[];

  loadingPlayerStats: boolean;
  loadingShape: boolean;
  loadingScoredGoals: boolean;
  loadingConcededGoals: boolean;

  ngOnInit() {
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Stats'
    );

    this.loadingScoredGoals = this.loadingConcededGoals = this.loadingPlayerStats = this.loadingShape = true;
    this.subs.sink = this.service.getPlayersStats().subscribe((res) => {
      this.playerStats = res;
      this.loadingPlayerStats = false;
    });

    this.subs.sink = this.service.getScoredGoalsPerGame().subscribe((res) => {
      this.scoredGoalsPerGame = res;
      this.loadingScoredGoals = false;
    });
    this.subs.sink = this.service.getConcededGoalsPerGame().subscribe((res) => {
      this.concededGoalsPerGame = res;
      this.loadingConcededGoals = false;
    });

    this.subs.sink = this.service.getShape().subscribe((stats) => {
      this.shape = stats;
      this.loadingShape = false;
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
