import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamPositionBlockComponent } from './team-position-block.component';

describe('TeamPositionBlockComponent', () => {
  let component: TeamPositionBlockComponent;
  let fixture: ComponentFixture<TeamPositionBlockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeamPositionBlockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamPositionBlockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
