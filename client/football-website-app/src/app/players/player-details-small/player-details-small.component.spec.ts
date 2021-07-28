import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PlayerDetailsSmallComponent } from './player-details-small.component';

describe('PlayerDetailsSmallComponent', () => {
  let component: PlayerDetailsSmallComponent;
  let fixture: ComponentFixture<PlayerDetailsSmallComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PlayerDetailsSmallComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayerDetailsSmallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
