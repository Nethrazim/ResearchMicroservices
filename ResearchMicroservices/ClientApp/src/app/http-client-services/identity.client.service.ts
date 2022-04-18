import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AuthenticateResponse } from '../entitites/AuthenticateResponse';
import { BaseResponse } from '../entitites/BaseResponse';

@Injectable({
  providedIn: 'root'
})
export class IdentityClientService {
  private HttpClient: HttpClient;
  private IdentityUrl: string;

  constructor(http: HttpClient, @Inject('IDENTITY_URL') identityUrl: string) {
    this.HttpClient = http;
    this.IdentityUrl = identityUrl;
  }

  loginUser(username : string, password : string) : Observable<AuthenticateResponse> {
    return this.HttpClient.post<AuthenticateResponse>(this.IdentityUrl + '/users/authenticate', { username: username, password: password });
  }

  createUser(username: string, email: string, password: string, role: number): Observable<BaseResponse> {
    return this.HttpClient.post<BaseResponse>(this.IdentityUrl + '/users/create', { username: username, email: email, password: password, role:role});
  }
}
