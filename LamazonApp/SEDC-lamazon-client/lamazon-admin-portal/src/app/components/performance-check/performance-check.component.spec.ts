import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerformanceCheckComponent } from './performance-check.component';

describe('PerformanceCheckComponent', () => {
  let component: PerformanceCheckComponent;
  let fixture: ComponentFixture<PerformanceCheckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PerformanceCheckComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PerformanceCheckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
