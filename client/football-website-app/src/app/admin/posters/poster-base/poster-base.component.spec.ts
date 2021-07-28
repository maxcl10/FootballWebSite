import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PosterBaseComponent } from './poster-base.component';

describe('PosterBaseComponent', () => {
  let component: PosterBaseComponent;
  let fixture: ComponentFixture<PosterBaseComponent>;

  beforeEach(async(() => {
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
