import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ApplicationStoreService } from '../services/application.store.service';

@Injectable({
providedIn: 'root'})
export class IsAdminLoggedInGuard implements CanActivate {

  constructor(private store: ApplicationStoreService, private router : Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    if (!this.store.Credentials) {
      this.router.navigate(['']);
    }

    if (!(this.store.Credentials.Role)) {
      this.router.navigate(['']);
    }

    if (this.store.Credentials.Role != 1) {
      this.router.navigate(['']);
    }

    return true;
  }
}
