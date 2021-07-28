import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { GameWidgetComponent } from './game-widget.component';

describe('GameWidgetComponent', () => {
  let component: GameWidgetComponent;
  let fixture: ComponentFixture<GameWidgetComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ GameWidgetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameWidgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
