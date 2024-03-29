import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

/*ROUTE GUARDS*/
import { IsLoggedInGuard } from './route-guards/loggedin.guard';
import { IsAdminLoggedInGuard } from './route-guards/admin.loggedin.guard';

/*COMPONENTS*/
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { TestComponent } from './components/test/test.component';
import { CreateAccountComponent } from './components/create-account/create-account.component';
import { ListItemComponent } from './components/list-item/list-item.component';
import { LoginComponent } from './components/login/login.component';
import { AdminNavMenuComponent } from './components/admin/admin-nav-menu/admin-nav-menu.component';
import { NavMenuItemComponent } from './components/admin/nav-menu-item/nav-menu-item.component';
import { AdminManageInstitutionComponent } from './components/admin/institution/admin-manage-institution/admin-manage-institution.component';
import { AdminManageAddressComponent } from './components/admin/institution/admin-manage-address/admin-manage-address.component';
import { AdminManageContactsComponent } from './components/admin/institution/admin-manage-contacts/admin-manage-contacts.component';
import { UpdateInstitutionComponent } from './components/admin/institution/update-institution/update-institution.component';
import { DeleteInstitutionComponent } from './components/admin/institution/delete-institution/delete-institution.component';
import { CreateInstitutionComponent } from './components/admin/institution/create-institution/create-institution.component';
import { InstitutionCardComponent } from './components/admin/institution/institution-card/institution-card.component';
import { AddressCardComponent } from './components/admin/institution/address-card/address-card.component';
import { ContactCardComponent } from './components/admin/institution/contact-card/contact-card.component';
import { SearchTeacherComponent } from './components/admin/teachers/search-teacher/search-teacher.component';
import { AddTeacherComponent } from './components/admin/teachers/add-teacher/add-teacher.component';

/*PAGES*/
import { AdminMyInstitutionPageComponent } from './pages/admin/admin-my-institution-page/admin-my-institution-page.component';
import { AdminTeacherPageComponent } from './pages/admin/admin-teacher-page/admin-teacher-page.component';
import { AdminStudentPageComponent } from './pages/admin/admin-student-page/admin-student-page.component';
import { AdminClassPageComponent } from './pages/admin/admin-class-page/admin-class-page.component';
import { AdminGradesPageComponent } from './pages/admin/admin-grades-page/admin-grades-page.component';
import { AdminCoursesPageComponent } from './pages/admin/admin-courses-page/admin-courses-page.component';
import { CreatePageComponent } from './pages/create-page/create-page.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { AdminLandingPageComponent } from './pages/admin-landing-page/admin-landing-page.component';



/*Material UI*/
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatTabsModule } from '@angular/material/tabs';
import { MatPaginatorModule } from '@angular/material/paginator';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    LoginPageComponent,
    CreateAccountComponent,
    CreatePageComponent,
    ListItemComponent,
    TestComponent,
    AdminLandingPageComponent,
    AdminNavMenuComponent,
    AdminMyInstitutionPageComponent,
    AdminTeacherPageComponent,
    AdminStudentPageComponent,
    AdminClassPageComponent,
    AdminGradesPageComponent,
    AdminCoursesPageComponent,
    NavMenuItemComponent,
    AdminManageInstitutionComponent,
    AdminManageAddressComponent,
    AdminManageContactsComponent,
    CreateInstitutionComponent,
    UpdateInstitutionComponent,
    DeleteInstitutionComponent,
    InstitutionCardComponent,
    AddressCardComponent,
    ContactCardComponent,
    SearchTeacherComponent,
    AddTeacherComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatDialogModule,
    MatCardModule,
    MatDividerModule,
    MatTabsModule,
    MatPaginatorModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [IsLoggedInGuard] },
      { path: 'login', component: LoginPageComponent },
      { path: 'register', component: CreatePageComponent },
      { path: 'test', component: TestComponent },
      { path: 'admin-home', component: AdminLandingPageComponent, canActivate: [IsAdminLoggedInGuard] },
      { path: 'admin/myinstitution', component: AdminMyInstitutionPageComponent, canActivate: [IsAdminLoggedInGuard] },
      { path: 'admin/teachers', component: AdminTeacherPageComponent, canActivate: [IsAdminLoggedInGuard] },
      { path: 'admin/teachers/add', component: AddTeacherComponent, canActivate: [IsAdminLoggedInGuard] },
      { path: 'admin/students', component: AdminStudentPageComponent, canActivate: [IsAdminLoggedInGuard] },
      { path: 'admin/classes', component: AdminClassPageComponent, canActivate: [IsAdminLoggedInGuard] },
      { path: 'admin/grades', component: AdminGradesPageComponent, canActivate: [IsAdminLoggedInGuard] },
      { path: 'admin/courses', component: AdminCoursesPageComponent, canActivate: [IsAdminLoggedInGuard] },
      { path: 'development', component: AddTeacherComponent },
    ]),
    BrowserAnimationsModule
  ],
  entryComponents: [CreateInstitutionComponent, UpdateInstitutionComponent, DeleteInstitutionComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
