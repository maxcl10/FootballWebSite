import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FixturesItemComponent } from './fixtures-item.component';

describe('FixturesItemComponent', () => {
  let component: FixturesItemComponent;
  let fixture: ComponentFixture<FixturesItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FixturesItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FixturesItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
