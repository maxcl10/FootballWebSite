import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ClubEventsContainerComponent } from './club-events-container.component';

describe('ClubEventsContainerComponent', () => {
  let component: ClubEventsContainerComponent;
  let fixture: ComponentFixture<ClubEventsContainerComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ClubEventsContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClubEventsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
