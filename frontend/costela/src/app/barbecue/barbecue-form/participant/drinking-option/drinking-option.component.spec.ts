import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DrinkingOptionComponent } from './drinking-option.component';

describe('DrinkingOptionComponent', () => {
  let component: DrinkingOptionComponent;
  let fixture: ComponentFixture<DrinkingOptionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DrinkingOptionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DrinkingOptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
