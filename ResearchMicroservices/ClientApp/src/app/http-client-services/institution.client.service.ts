import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AuthenticateResponse } from '../entitites/responses/identity/AuthenticateResponse';
import { BaseResponse } from '../entitites/BaseResponse';
import { ChangePasswordResponse } from '../entitites/responses/identity/ChangePasswordResponse';
import { ApplicationStoreService } from '../services/application.store.service';
import { GetByAdminIdResponse } from '../entitites/responses/institution/GetByAdminIdResponse';
import { CreateInstitutionResponse } from '../entitites/responses/institution/CreateInstitutionResponse';
import { EntityResponse } from '../entitites/EntityResponse';
import { Institution } from '../entitites/responses/institution/Institution';
import { ValueResponse } from '../entitites/ValueResponse';

@Injectable({
  providedIn: 'root'
})
export class InstitutionClientService {
  private Url: string;

  constructor(private HttpClient: HttpClient, private store: ApplicationStoreService, @Inject('INSTITUTION_URL') Url: string) {
    this.Url = Url;
  }

  getByAdminId(systemUserId: string): Observable<GetByAdminIdResponse> {
    let httpOptions = {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.store.Credentials.TokenValue}`
      })
    };
    return this.HttpClient.post<GetByAdminIdResponse>(this.Url + '/institution/getByAdminId', { AdminId: systemUserId }, httpOptions);
  }

  createInstitution(systemUserId: string, name: string): Observable<CreateInstitutionResponse> {
    let httpOptions = {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.store.Credentials.TokenValue}`
      })
    };
    return this.HttpClient.post<CreateInstitutionResponse>(this.Url + '/institution/create', { AdminId: systemUserId, Name: name }, httpOptions);
  }

  updateInstitution(institutionId: number, name: string): Observable<EntityResponse<Institution>> {
    let httpOptions = {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.store.Credentials.TokenValue}`
      })
    };

    return this.HttpClient.post<EntityResponse<Institution>>(this.Url + '/institution/update', { InstitutionId: institutionId, Name: name }, httpOptions);
  }

  deleteInstitution(institutionId: number): Observable<ValueResponse<boolean>> {
    let httpOptions = {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.store.Credentials.TokenValue}`
      }),
      body: {InstitutionId: institutionId}
    };

    return this.HttpClient.delete<ValueResponse<boolean>>(this.Url + '/institution/delete', httpOptions);  
  }
}
