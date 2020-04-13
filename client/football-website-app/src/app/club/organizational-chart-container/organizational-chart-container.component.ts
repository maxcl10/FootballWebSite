import { Component, OnInit } from '@angular/core';
import { ClubService } from '../../core/services/club.service';
import { OrganizationalItem } from '../../shared/models/organizational-item.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'fws-organizational-chart-container',
  templateUrl: './organizational-chart-container.component.html',
  styleUrls: ['./organizational-chart-container.component.css'],
})
export class OrganizationalChartContainerComponent implements OnInit {
  public organizationChart$: Observable<OrganizationalItem[]>;

  constructor(private service: ClubService) {}

  ngOnInit() {
    this.organizationChart$ = this.service.getOrganizationalChart();
  }
}
