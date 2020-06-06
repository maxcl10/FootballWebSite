import {
  Component,
  OnInit,
  Input,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import { StatsService } from '../../core/services/stats.service';

@Component({
  selector: 'fws-stats-last-results',
  templateUrl: './stats-last-results.component.html',
  styleUrls: ['./stats-last-results.component.css'],
})
export class StatsLastResultsComponent implements OnInit, OnChanges {
  @Input()
  public shape: string[];

  public displayShape: String[];

  constructor(private statsService: StatsService) {}

  ngOnInit() {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.shape.previousValue !== changes.shape.currentValue) {
      this.displayShape = changes.shape.currentValue.slice(
        changes.shape.currentValue.length - 5
      );
    }
  }
}
