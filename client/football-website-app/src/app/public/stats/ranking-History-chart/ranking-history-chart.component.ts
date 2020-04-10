import { Component, OnInit, AfterViewInit } from '@angular/core';
// import { CORE_DIRECTIVES, FORM_DIRECTIVES, NgClass } from '@angular/common';
import { StatsService } from '../../../core/services/stats.service';

@Component({
  selector: 'fws-ranking-history-chart',
  templateUrl: './ranking-history-chart.component.html',
  providers: [StatsService]
})
export class RankingHistoryComponent {}

//     public lineChartData: Array<any> = [
//         { data: [10, 4, 1, 1, 4, 6], label: 'Position' },
//     ];

//     public lineChartLabels: Array<any> = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];

//     public lineChartOptions: any = {
//         animation: false,
//         responsive: true
//     };

//     constructor(private statsService: StatsService) {
//  this.statsService.getRankingHistory().subscribe(
//             res => {

//                 // this.lineChartLabels = new Array[res.length];
//                 // res.forEach(element => {
//                 //     this.lineChartLabels.push(element.uploadDate);
//                 // });

//                 let _lineChartData: Array<any> = new Array(1);

//                 for (let i = 0; i < 1; i++) {
//                     _lineChartData[i] = { data: new Array(res.length), label: 'position' };
//                     for (let j = 0; j < res.length; j++) {
//                         _lineChartData[i].data[j] = res[j];
//                     }
//                 }

//                 this.lineChartData = _lineChartData;
//             },
//             error => this.errorMessage = <any>error);
//     }

//     public errorMessage: string;

//     // events
//     public chartClicked(e: any): void {
//         console.log(e);
//     }

//     public chartHovered(e: any): void {
//         console.log(e);
//     }

//     public lineChartColours: Array<any> = [
//         { // grey
//             backgroundColor: 'rgba(148,159,177,0.2)',
//             borderColor: 'rgba(148,159,177,1)',
//             pointBackgroundColor: 'rgba(148,159,177,1)',
//             pointBorderColor: '#fff',
//             pointHoverBackgroundColor: '#fff',
//             pointHoverBorderColor: 'rgba(148,159,177,0.8)'
//         },
//         { // dark grey
//             backgroundColor: 'rgba(77,83,96,0.2)',
//             borderColor: 'rgba(77,83,96,1)',
//             pointBackgroundColor: 'rgba(77,83,96,1)',
//             pointBorderColor: '#fff',
//             pointHoverBackgroundColor: '#fff',
//             pointHoverBorderColor: 'rgba(77,83,96,1)'
//         },
//         { // grey
//             backgroundColor: 'rgba(148,159,177,0.2)',
//             borderColor: 'rgba(148,159,177,1)',
//             pointBackgroundColor: 'rgba(148,159,177,1)',
//             pointBorderColor: '#fff',
//             pointHoverBackgroundColor: '#fff',
//             pointHoverBorderColor: 'rgba(148,159,177,0.8)'
//         }
//     ];
//     public lineChartLegend: boolean = true;
//     public lineChartType: string = 'line';

//     ngAfterViewInit() {

//     }
