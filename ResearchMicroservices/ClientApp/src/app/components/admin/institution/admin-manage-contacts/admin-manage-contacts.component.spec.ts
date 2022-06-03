import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminManageContactsComponent } from './admin-manage-contacts.component';

describe('AdminManageContactsComponent', () => {
  let component: AdminManageContactsComponent;
  let fixture: ComponentFixture<AdminManageContactsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminManageContactsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminManageContactsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
