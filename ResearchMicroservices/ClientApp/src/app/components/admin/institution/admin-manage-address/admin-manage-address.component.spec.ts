import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminManageAddressComponent } from './admin-manage-address.component';

describe('AdminManageAddressComponent', () => {
  let component: AdminManageAddressComponent;
  let fixture: ComponentFixture<AdminManageAddressComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminManageAddressComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminManageAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
