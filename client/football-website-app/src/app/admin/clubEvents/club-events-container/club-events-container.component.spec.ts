import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClubEventsContainerComponent } from './club-events-container.component';

describe('ClubEventsContainerComponent', () => {
  let component: ClubEventsContainerComponent;
  let fixture: ComponentFixture<ClubEventsContainerComponent>;

  beforeEach(async(() => {
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
