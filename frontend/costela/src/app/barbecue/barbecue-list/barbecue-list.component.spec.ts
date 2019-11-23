import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BarbecueListComponent } from './barbecue-list.component';

describe('BarbecueListComponent', () => {
  let component: BarbecueListComponent;
  let fixture: ComponentFixture<BarbecueListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BarbecueListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BarbecueListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
