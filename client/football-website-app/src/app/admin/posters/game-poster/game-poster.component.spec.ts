import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { GamePosterComponent } from './game-poster.component';

describe('GamePosterComponent', () => {
  let component: GamePosterComponent;
  let fixture: ComponentFixture<GamePosterComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ GamePosterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GamePosterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
