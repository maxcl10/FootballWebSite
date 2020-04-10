import { Component, OnInit } from '@angular/core';
import { Stricker } from '../../../shared/models/stricker.model';
import { StatsService } from '../../../core/services/stats.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'fws-edit-player-stats',
  templateUrl: './edit-player-stats.component.html',
  styleUrls: ['./edit-player-stats.component.css']
})
export class EditPlayerStatsComponent implements OnInit {
  public stricker: Stricker;
  public errorMessage: String;

  constructor(
    private statService: StatsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.statService.getStricker(id).subscribe(result => {
      this.stricker = result;
    });
  }

  public goBack() {
    window.history.back();
  }

  public saveStricker() {
    this.statService.saveStricker(this.stricker).subscribe(
      stricker => {
        this.goBack();
      },
      error => (this.errorMessage = <any>error)
    );
  }
}
