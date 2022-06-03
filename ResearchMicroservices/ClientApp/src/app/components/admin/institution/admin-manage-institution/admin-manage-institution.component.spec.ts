import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminManageInstitutionComponent } from './admin-manage-institution.component';

describe('AdminCreateInstitutionComponent', () => {
  let component: AdminManageInstitutionComponent;
  let fixture: ComponentFixture<AdminManageInstitutionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminManageInstitutionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminManageInstitutionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
