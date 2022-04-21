import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ApplicationStoreService } from '../services/application.store.service';

@Injectable({
providedIn: 'root'})
export class IsLoggedInGuard implements CanActivate {

  constructor(private store: ApplicationStoreService, private router : Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (!this.store.JwtToken) {
      this.router.navigate(['']);
    }
    return true;
  }
}
