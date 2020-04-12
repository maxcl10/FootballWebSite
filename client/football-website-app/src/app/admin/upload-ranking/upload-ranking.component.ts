import { Component, OnInit } from '@angular/core';
import { RankingsService } from '../../ranking/rankings.service';

@Component({
  selector: 'fws-upload-ranking',
  templateUrl: './upload-ranking.component.html',
})
export class UploadRankingComponent {
  public uploadFile: any;
  public success = false;
  public error: boolean;
  public errorMessage: string;

  public options: Object = {
    url: 'https://fcuwebapi.azurewebsites.net/api/ranking',
  };

  constructor(private rankingsService: RankingsService) {}

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
    this.rankingsService.updateRankingFromLafa().subscribe(
      (res) => {
        this.success = true;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public goBack() {
    window.history.back();
  }
}
