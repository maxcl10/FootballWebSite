import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TeamsContainerComponent } from './teams-container.component';

describe('TeamsContainerComponent', () => {
  let component: TeamsContainerComponent;
  let fixture: ComponentFixture<TeamsContainerComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TeamsContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
