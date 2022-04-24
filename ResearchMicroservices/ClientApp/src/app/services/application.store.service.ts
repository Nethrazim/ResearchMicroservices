import { Injectable } from '@angular/core';
import { Token } from '../entitites/Token';

@Injectable({
  providedIn: 'root'
})
export class ApplicationStoreService {
  public Credentials: Token = null;

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
