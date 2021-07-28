import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PosterBaseComponent } from './poster-base.component';

describe('PosterBaseComponent', () => {
  let component: PosterBaseComponent;
  let fixture: ComponentFixture<PosterBaseComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PosterBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PosterBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
