import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RankingContainerComponent } from './ranking-container.component';

describe('RankingContainerComponent', () => {
  let component: RankingContainerComponent;
  let fixture: ComponentFixture<RankingContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RankingContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RankingContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
