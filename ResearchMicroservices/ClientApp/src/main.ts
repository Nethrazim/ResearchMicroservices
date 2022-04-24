import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

export function getIdentityUrl() {
  return "https://localhost:44326/api/Identity";
}

export function getInstitutionUrl() {
  return "https://localhost:44304/api/Institution";
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: 'IDENTITY_URL', useFactory: getIdentityUrl, deps: [] },
  { provide: 'INSTITUTION_URL', useFactory: getInstitutionUrl, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
