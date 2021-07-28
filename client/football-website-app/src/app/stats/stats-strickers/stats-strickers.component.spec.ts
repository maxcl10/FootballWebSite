import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { StatsStrickersComponent } from './stats-strickers.component';

describe('StatsStrickersComponent', () => {
  let component: StatsStrickersComponent;
  let fixture: ComponentFixture<StatsStrickersComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ StatsStrickersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatsStrickersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
