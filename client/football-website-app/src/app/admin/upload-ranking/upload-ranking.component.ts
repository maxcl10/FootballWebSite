import { Component, OnInit } from '@angular/core';
import { LeagueRankingsService } from '../../core/services/league-table.service';

@Component({
  selector: 'fws-upload-ranking',
  templateUrl: './upload-ranking.component.html',
  providers: [LeagueRankingsService]
})
export class UploadRankingComponent {
  public uploadFile: any;
  public success = false;
  public error: boolean;
  public errorMessage: string;

  public options: Object = {
    url: 'https://fcuwebapi.azurewebsites.net/api/ranking'
  };

  constructor(private leagueService: LeagueRankingsService) {}

  public handleUpload(data: any): void {
    if (data && data.response) {
      if (data.response === true) {
        this.success = true;
        this.error = false;
      } else {
        data = JSON.parse(data.response);
        this.uploadFile = data;
        this.error = true;
        this.success = false;
      }
    }
  }

  public updateRankingFromLafa() {
    this.leagueService.updateRankingFromLafa().subscribe(
      res => {
        this.success = true;
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public goBack() {
    window.history.back();
  }
}
