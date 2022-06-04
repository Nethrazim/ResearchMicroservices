import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { BaseResponse } from '../entitites/BaseResponse';
import { ApplicationStoreService } from '../services/application.store.service';
import { EntityResponse } from '../entitites/EntityResponse';
import { ValueResponse } from '../entitites/ValueResponse';
import { Teacher } from '../entitites/responses/teacher/Teacher';
import { EntitiesResponse } from '../entitites/EntitiesResponse';
import { PagedResponse } from '../entitites/PagedResponse';

@Injectable({
  providedIn: 'root'
})
export class TeacherClientService {
  private Url: string;

  constructor(private HttpClient: HttpClient, private store: ApplicationStoreService, @Inject('TEACHER_URL') Url: string) {
    this.Url = Url;
  }


  createTeacher(institutionId: number, firstName: string, middleName: string, lastName: string, gender: boolean): Observable<EntityResponse<Teacher>>
  {

    let httpOptions = {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.store.Credentials.TokenValue}`
      })
    };

    return this.HttpClient.post<EntityResponse<Teacher>>(this.Url + '/teacher/create',
    {
        InstitutionId: institutionId,
        FirstName: firstName,
        LastName: lastName,
        MiddleName: middleName,
        Gender: gender
    }, httpOptions);
  }

  updateTeacher(id: number ,institutionId: number, firstName: string, middleName: string, lastName: string, gender: boolean): Observable<EntityResponse<Teacher>> {

    let httpOptions = {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.store.Credentials.TokenValue}`
      })
    };

    return this.HttpClient.put<EntityResponse<Teacher>>(this.Url + '/teacher/put',
      {
        Id: id,
        InstitutionId: institutionId,
        FirstName: firstName,
        LastName: lastName,
        MiddleName: middleName,
        Gender: gender
      }, httpOptions);
  }

  deleteTeacher(id: number): Observable<ValueResponse<boolean>> {
    let httpOptions = {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.store.Credentials.TokenValue}`
      }),
      body: {Id: id}
    };

    return this.HttpClient.delete<ValueResponse<boolean>>(this.Url + '/teacher/delete', httpOptions);
  }

  getByInstitutionId(institutionId: number, pageIndex: number, pageSize: number, firstName: string, middleName:string, lastName:string): Observable<PagedResponse<Teacher>> {
    var httpOptions = {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.store.Credentials.TokenValue}`
      })
    };

    var params = new URLSearchParams({
      InstitutionId: institutionId.toString(),
      PageIndex: pageIndex.toString(),
      PageSize: pageSize.toString()
    });

    if (firstName) {
      params.set("FirstName", firstName);
    }

    if (middleName) {
      params.set("MiddleName", middleName);
    }

    if (lastName) {
      params.set("LastName", lastName);
    }

    return this.HttpClient.get<PagedResponse<Teacher>>(this.Url + '/teacher/getByInstitutionId?' + params.toString(), httpOptions);
  }

}
