import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PlayersCarouselComponent } from './players-carousel.component';

describe('PlayersCarouselComponent', () => {
  let component: PlayersCarouselComponent;
  let fixture: ComponentFixture<PlayersCarouselComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PlayersCarouselComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayersCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
