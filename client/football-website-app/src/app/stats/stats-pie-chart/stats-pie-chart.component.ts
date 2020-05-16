import {
  Component,
  OnInit,
  Input,
  ChangeDetectionStrategy,
} from '@angular/core';
import { StatsService } from '../../core/services/stats.service';
import { AppConfig } from '../../app.config';

@Component({
  selector: 'fws-stats-pie-chart',
  templateUrl: './stats-pie-chart.component.html',
  styleUrls: ['./stats-pie-chart.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StatsPieChartComponent {
  // Doughnut
  public doughnutChartLabels: string[] = ['Gagnés', 'Nuls', 'Perdus'];
  public doughnutChartType = 'doughnut';
  public doughnutChartData: number[];
  public doughnutChartColors: any[];
  public doughnutChartOptions: any;

  @Input()
  set shape(val: string[]) {
    if (val) {
      const lossCount = val.filter((o) => o === 'L').length;
      const drawCount = val.filter((o) => o === 'D').length;
      const wonCount = val.filter((o) => o === 'W').length;
      this.doughnutChartData = [wonCount, drawCount, lossCount];

      this.doughnutChartType = 'doughnut';
      this.doughnutChartColors = [
        {
          backgroundColor: [
            AppConfig.settings.properties.mainColor,
            '#ECF0F1',
            '#9b2816',
          ],
          borderColor: 'rgba(255,255,255,1)',
          pointBackgroundColor: 'rgba(148,159,177,1)',
          pointBorderColor: '#fff',
          pointHoverBackgroundColor: '#fff',
          pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        },
      ];

      this.doughnutChartOptions = {
        legend: {
          display: true,
        },
      };
    }
  }
  public errorMessage: string;
}
