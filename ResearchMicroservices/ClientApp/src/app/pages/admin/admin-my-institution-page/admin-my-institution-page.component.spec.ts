import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminMyInstitutionPageComponent } from './admin-my-institution-page.component';

describe('AdminMyInstitutionPageComponent', () => {
  let component: AdminMyInstitutionPageComponent;
  let fixture: ComponentFixture<AdminMyInstitutionPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminMyInstitutionPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminMyInstitutionPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
