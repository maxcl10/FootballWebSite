import { Component, OnInit } from '@angular/core';
import { StatsService } from '../../core/services/stats.service';

@Component({
  selector: 'fws-stats-last-results',
  templateUrl: './stats-last-results.component.html',
  styleUrls: ['./stats-last-results.component.css'],
})
export class StatsLastResultsComponent implements OnInit {
  public stats: string[];

  constructor(private statsService: StatsService) {}

  ngOnInit() {
    this.statsService.getShape().subscribe((stats) => {
      this.stats = stats.slice(stats.length - 5);
    });
  }
}
