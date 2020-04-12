import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SponsorsContainerComponent } from './sponsors-container.component';

describe('SponsorsContainerComponent', () => {
  let component: SponsorsContainerComponent;
  let fixture: ComponentFixture<SponsorsContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SponsorsContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SponsorsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
