import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganizationalChartContainerComponent } from './organizational-chart-container.component';

describe('OrganizationalChartContainerComponent', () => {
  let component: OrganizationalChartContainerComponent;
  let fixture: ComponentFixture<OrganizationalChartContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrganizationalChartContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganizationalChartContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
