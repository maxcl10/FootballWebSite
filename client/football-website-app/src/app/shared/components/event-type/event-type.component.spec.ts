import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { EventTypeComponent } from './event-type.component';

describe('EventTypeComponent', () => {
  let component: EventTypeComponent;
  let fixture: ComponentFixture<EventTypeComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EventTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
