import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuypolicyComponent } from './buypolicy.component';

describe('BuypolicyComponent', () => {
  let component: BuypolicyComponent;
  let fixture: ComponentFixture<BuypolicyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuypolicyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuypolicyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
