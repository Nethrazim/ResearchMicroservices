import { Injectable } from '@angular/core';
import { Institution } from '../entitites/responses/institution/Institution';
import { Token } from '../entitites/Token';

@Injectable({
  providedIn: 'root'
})
export class ApplicationStoreService {
  public Credentials: Token = null;
  public Institution: Institution = null;

  constructor() { }

  isLoggedIn(): boolean {
    if (this.Credentials)
      return true;
    else
      return false;
  }

  deleteCredentials() {
    this.Credentials = null;
  }

  setCredentials(token: Token) {
    this.Credentials = token;
  }
}
