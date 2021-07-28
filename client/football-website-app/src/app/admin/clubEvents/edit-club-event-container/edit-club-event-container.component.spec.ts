import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { EditClubEventContainerComponent } from './edit-club-event-container.component';

describe('EditClubEventContainerComponent', () => {
  let component: EditClubEventContainerComponent;
  let fixture: ComponentFixture<EditClubEventContainerComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EditClubEventContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditClubEventContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
