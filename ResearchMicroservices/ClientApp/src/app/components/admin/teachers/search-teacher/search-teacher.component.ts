import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Teacher } from '../../../../entitites/responses/teacher/Teacher';
import { TeacherClientService } from '../../../../http-client-services/teacher.client.service';
import { ApplicationStoreService } from '../../../../services/application.store.service';

@Component({
  selector: 'app-search-teacher',
  templateUrl: './search-teacher.component.html',
  styleUrls: ['./search-teacher.component.css']
})
export class SearchTeacherComponent implements OnInit {
  public displayedColumns: string[] = ['FirstName', 'MiddleName', 'LastName', 'Gender', 'Action'];

  public teachers: Teacher[];

  public pageIndex: number = 1;
  public pageSize: number = 10;
  public totalCount: number = 0;

  public firstName: string = null;
  public middleName: string = null;
  public lastName: string = null;

  constructor(private store: ApplicationStoreService, private teachersClient : TeacherClientService) { }

  ngOnInit() {
    this.getTeachers();
  }

  getTeachers() {
    if (this.store.Institution) {
      this.teachersClient.getByInstitutionId(this.store.Institution.Id, this.pageIndex, this.pageSize,this.firstName,this.middleName,this.lastName)
        .subscribe(response => {
          if (response.HasError) {
            alert(response.Message);
          }
          else {
            this.teachers = response.Entity;
            this.totalCount = response.TotalCount;
          }
        })
    }
  }
  onPageSelected($event: PageEvent)  {
    this.pageIndex = ($event.pageIndex + 1);
    this.getTeachers();
  }
  onSearch() {
    this.getTeachers();
  }

  onClearSearch() {
    this.firstName = null;
    this.middleName = null;
    this.lastName = null;
    this.getTeachers();
  }
}
