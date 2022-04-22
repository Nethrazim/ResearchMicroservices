import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AuthenticateResponse } from '../entitites/responses/identity/AuthenticateResponse';
import { BaseResponse } from '../entitites/BaseResponse';
import { ChangePasswordResponse } from '../entitites/responses/identity/ChangePasswordResponse';
import { ApplicationStoreService } from '../services/application.store.service';

@Injectable({
  providedIn: 'root'
})
export class IdentityClientService {
  private IdentityUrl: string;

  constructor(private HttpClient: HttpClient, private store: ApplicationStoreService, @Inject('IDENTITY_URL') identityUrl: string) {
    this.IdentityUrl = identityUrl;
  }

  loginUser(username : string, password : string) : Observable<AuthenticateResponse> {
    return this.HttpClient.post<AuthenticateResponse>(this.IdentityUrl + '/users/authenticate', { Username: username, Password: password });
  }

  createUser(username: string, email: string, password: string, role: number): Observable<BaseResponse> {
    return this.HttpClient.post<BaseResponse>(this.IdentityUrl + '/users/create', { Username: username, Email: email, Password: password, Role:role});
  }

  changePassword(username: string, newPassword: string): Observable<ChangePasswordResponse> {
    let httpOptions = {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.store.Credentials.TokenValue}`
      })
    }
    return this.HttpClient.post<ChangePasswordResponse>(this.IdentityUrl + '/users/changepassword', {Username: username, NewPassword: newPassword}, httpOptions);
  }
}
