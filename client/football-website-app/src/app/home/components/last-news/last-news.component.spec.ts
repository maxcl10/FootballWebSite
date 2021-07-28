import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { LastNewsComponent } from './last-news.component';

describe('LastNewsComponent', () => {
  let component: LastNewsComponent;
  let fixture: ComponentFixture<LastNewsComponent>;

  beforeEach(waitForAsync(() => {
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
