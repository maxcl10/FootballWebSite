import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { FixturesContainerComponent } from './fixtures-container.component';

describe('FixturesContainerComponent', () => {
  let component: FixturesContainerComponent;
  let fixture: ComponentFixture<FixturesContainerComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ FixturesContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FixturesContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
