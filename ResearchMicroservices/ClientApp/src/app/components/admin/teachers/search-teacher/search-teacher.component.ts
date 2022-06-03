import { Component, OnInit } from '@angular/core';
import { Teacher } from '../../../../entitites/responses/teacher/Teacher';

@Component({
  selector: 'app-search-teacher',
  templateUrl: './search-teacher.component.html',
  styleUrls: ['./search-teacher.component.css']
})
export class SearchTeacherComponent implements OnInit {
  public displayedColumns: string[] = ['FirstName', 'MiddleName', 'LastName', 'Gender', 'Action'];
  public teachers: Teacher[];
  constructor() { }

  ngOnInit() {
  }

  onPageSelected($event) {
    alert($event);
  }
}
