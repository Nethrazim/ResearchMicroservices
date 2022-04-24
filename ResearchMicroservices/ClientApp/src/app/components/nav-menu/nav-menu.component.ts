import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApplicationStoreService } from '../../services/application.store.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  constructor(private store: ApplicationStoreService, private router: Router) {
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  showLogin() { return !this.store.isLoggedIn(); }
  showLogout() { return this.store.isLoggedIn(); }

  logout() {
    this.store.deleteCredentials();
    this.router.navigate(['']);
  }
}
