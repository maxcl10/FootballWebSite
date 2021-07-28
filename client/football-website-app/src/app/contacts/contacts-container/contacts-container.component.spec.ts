import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ContactsContainerComponent } from './contacts-container.component';

describe('ContactsContainerComponent', () => {
  let component: ContactsContainerComponent;
  let fixture: ComponentFixture<ContactsContainerComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ContactsContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
