import { Component, OnInit } from '@angular/core';
import { StatsService } from '../../core/services/stats.service';
import { AppConfig } from '../../app.config';

@Component({
  selector: 'fws-stats-pie-chart',
  templateUrl: './stats-pie-chart.component.html',
  styleUrls: ['./stats-pie-chart.component.css'],
})
export class StatsPieChartComponent implements OnInit {
  // Doughnut
  public doughnutChartLabels: string[] = ['Gagnés', 'Nuls', 'Perdus'];
  public doughnutChartType = 'doughnut';
  public doughnutChartData: number[];
  public doughnutChartColors: any[];
  public doughnutChartOptions: any;

  public errorMessage: string;

  constructor(private statsService: StatsService) {}

  // events
  public chartClicked(e: any): void {
    console.log(e);
  }

  public chartHovered(e: any): void {
    console.log(e);
  }

  public ngOnInit() {
    this.statsService.getShape().subscribe(
      (res) => {
        const lossCount = res.filter((o) => o === 'P').length;
        const drawCount = res.filter((o) => o === 'N').length;
        const wonCount = res.filter((o) => o === 'G').length;
        this.doughnutChartData = [wonCount, drawCount, lossCount];
      },
      (error) => (this.errorMessage = <any>error)
    );

    this.doughnutChartType = 'doughnut';
    this.doughnutChartColors = [
      {
        backgroundColor: [
          AppConfig.settings.properties.mainColor,
          '#ECF0F1',
          '#E74C3C',
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
        labels: {
          // fontColor: '#3f2b5d'
        },
      },
      // title: {
      //   display: true,
      //   text: 'Custom Chart Title',
      //   fontColor: '#FFF'
      // }
    };
  }
}
