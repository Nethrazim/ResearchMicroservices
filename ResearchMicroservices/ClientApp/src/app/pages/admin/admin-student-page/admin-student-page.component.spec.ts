import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminStudentPageComponent } from './admin-student-page.component';

describe('AdminStudentPageComponent', () => {
  let component: AdminStudentPageComponent;
  let fixture: ComponentFixture<AdminStudentPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminStudentPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminStudentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
