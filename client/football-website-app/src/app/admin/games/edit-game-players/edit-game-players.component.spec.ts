import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditGamePlayersComponent } from './edit-game-players.component';

describe('EditGamePlayersComponent', () => {
  let component: EditGamePlayersComponent;
  let fixture: ComponentFixture<EditGamePlayersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditGamePlayersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditGamePlayersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
