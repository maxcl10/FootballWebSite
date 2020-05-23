import { Component, OnInit, Input } from '@angular/core';
import { LogoService } from '../../../core/services/logo.service';

@Component({
  selector: 'fws-logo',
  templateUrl: './logo.component.html',
  styleUrls: ['./logo.component.css'],
})
export class LogoComponent implements OnInit {
  @Input() team;

  @Input() size = 30;

  imageUrl: string;

  constructor(private logoService: LogoService) {}

  ngOnInit(): void {
    this.imageUrl = this.logoService.getLogoPath(this.team, this.size);
  }
}
