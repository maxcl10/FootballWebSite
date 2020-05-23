import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LastNewsComponent } from './last-news.component';

describe('LastNewsComponent', () => {
  let component: LastNewsComponent;
  let fixture: ComponentFixture<LastNewsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LastNewsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LastNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
