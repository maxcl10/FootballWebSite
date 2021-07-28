import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ArticleContainerComponent } from './article-container.component';

describe('ArticleContainerComponent', () => {
  let component: ArticleContainerComponent;
  let fixture: ComponentFixture<ArticleContainerComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ArticleContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticleContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
