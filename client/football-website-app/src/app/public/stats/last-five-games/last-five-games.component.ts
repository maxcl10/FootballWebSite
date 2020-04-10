import { Component, OnInit } from '@angular/core';
import { StatsService } from '../../../core/services/stats.service';

@Component({
  selector: 'fws-last-five-games',
  templateUrl: './last-five-games.component.html',
  providers: [StatsService]
})
export class LastFiveGamesComponent implements OnInit {
  public stats: string[];

  constructor(private statsService: StatsService) {}

  ngOnInit() {
    this.statsService.getShape().subscribe(stats => {
      this.stats = stats.slice(stats.length - 5);
    });
  }
}
