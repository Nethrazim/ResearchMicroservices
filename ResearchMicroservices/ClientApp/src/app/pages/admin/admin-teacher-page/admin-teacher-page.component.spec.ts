import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminTeacherPageComponent } from './admin-teacher-page.component';

describe('AdminTeacherPageComponent', () => {
  let component: AdminTeacherPageComponent;
  let fixture: ComponentFixture<AdminTeacherPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminTeacherPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminTeacherPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
