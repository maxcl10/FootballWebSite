import {
  Component,
  OnInit,
  Input,
  ChangeDetectionStrategy,
} from '@angular/core';

import { Ranking } from '../../shared/models/league-table.model';

@Component({
  selector: 'fws-ranking-table',
  styleUrls: ['./ranking-table.component.scss'],
  templateUrl: './ranking-table.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RankingTableComponent implements OnInit {
  @Input()
  public ranking: Ranking[];

  @Input()
  public homeTeam: string;

  constructor() {}

  public ngOnInit() {}
}
