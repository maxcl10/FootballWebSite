import { Component, OnInit, Input } from '@angular/core';
import { StatsService } from '../../core/services/stats.service';

@Component({
  selector: 'fws-stats-last-results',
  templateUrl: './stats-last-results.component.html',
  styleUrls: ['./stats-last-results.component.css'],
})
export class StatsLastResultsComponent implements OnInit {
  @Input()
  public shape: string[];

  constructor(private statsService: StatsService) {}

  ngOnInit() {}
}
