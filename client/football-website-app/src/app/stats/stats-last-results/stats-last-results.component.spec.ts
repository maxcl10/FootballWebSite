import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatsLastResultsComponent } from './stats-last-results.component';

describe('StatsLastResultsComponent', () => {
  let component: StatsLastResultsComponent;
  let fixture: ComponentFixture<StatsLastResultsComponent>;

  beforeEach(async(() => {
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
