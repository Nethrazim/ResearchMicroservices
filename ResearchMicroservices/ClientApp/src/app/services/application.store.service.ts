import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApplicationStoreService {
  public JwtToken: string;
  public Username: string;
  public Email: string
  public TokenExpiresOn: number;

  constructor() { }
}
