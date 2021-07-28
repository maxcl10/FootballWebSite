import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { StatsPieChartComponent } from './stats-pie-chart.component';

describe('StatsPieChartComponent', () => {
  let component: StatsPieChartComponent;
  let fixture: ComponentFixture<StatsPieChartComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ StatsPieChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatsPieChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
