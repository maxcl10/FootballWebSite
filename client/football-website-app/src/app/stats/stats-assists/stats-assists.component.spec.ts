import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatsAssistsComponent } from './stats-assists.component';

describe('StatsAssistsComponent', () => {
  let component: StatsAssistsComponent;
  let fixture: ComponentFixture<StatsAssistsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatsAssistsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatsAssistsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
