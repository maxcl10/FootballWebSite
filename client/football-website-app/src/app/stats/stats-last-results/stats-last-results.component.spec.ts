import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { StatsLastResultsComponent } from './stats-last-results.component';

describe('StatsLastResultsComponent', () => {
  let component: StatsLastResultsComponent;
  let fixture: ComponentFixture<StatsLastResultsComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ StatsLastResultsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatsLastResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
