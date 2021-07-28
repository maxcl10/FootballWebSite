import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PitchComponent } from './pitch.component';

describe('PitchComponent', () => {
  let component: PitchComponent;
  let fixture: ComponentFixture<PitchComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PitchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PitchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
