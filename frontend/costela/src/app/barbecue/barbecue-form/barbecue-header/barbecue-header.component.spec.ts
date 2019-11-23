import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BarbecueHeaderComponent } from './barbecue-header.component';

describe('BarbecueHeaderComponent', () => {
  let component: BarbecueHeaderComponent;
  let fixture: ComponentFixture<BarbecueHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BarbecueHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BarbecueHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
