import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeasonSummaryComponent } from './season-summary.component';

describe('SeasonSummaryComponent', () => {
  let component: SeasonSummaryComponent;
  let fixture: ComponentFixture<SeasonSummaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeasonSummaryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeasonSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
