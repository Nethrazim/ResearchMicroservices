import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminGradesPageComponent } from './admin-grades-page.component';

describe('AdminGradesPageComponent', () => {
  let component: AdminGradesPageComponent;
  let fixture: ComponentFixture<AdminGradesPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminGradesPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminGradesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
