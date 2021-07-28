import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ClubsListComponent } from './clubs-list.component';

describe('ClubsListComponent', () => {
  let component: ClubsListComponent;
  let fixture: ComponentFixture<ClubsListComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ClubsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClubsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
