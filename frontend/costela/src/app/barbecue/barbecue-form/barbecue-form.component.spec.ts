import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BarbecueFormComponent } from './barbecue-form.component';

describe('BarbecueFormComponent', () => {
  let component: BarbecueFormComponent;
  let fixture: ComponentFixture<BarbecueFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BarbecueFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BarbecueFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
