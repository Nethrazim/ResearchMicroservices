import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserRoles } from '../../data-reference/user-roles';
import { BaseResponse } from '../../entitites/BaseResponse';
import { IdentityClientService } from '../../http-client-services/identity.client.service';
import { InstitutionClientService } from '../../http-client-services/institution.client.service';
import { ApplicationStoreService } from '../../services/application.store.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  username: string = "";
  password: string = "";
  loginFormGroup: FormGroup;

  constructor(private identityClient: IdentityClientService,
      private institutionClient: InstitutionClientService,
      private store: ApplicationStoreService
    , private router: Router
  )
  {
  }
  
  ngOnInit() {
    this.loginFormGroup = new FormGroup({
      fcUsername: new FormControl(this.username, [Validators.required, Validators.minLength(6)]),
      fcPassword: new FormControl(this.password, [Validators.required, Validators.minLength(12)])

    });
  }

  get getUsername() { return this.loginFormGroup.get('fcUsername').value; }
  get getPassword() { return this.loginFormGroup.get('fcPassword').value; }

  get validateUsername() {
    return (
      this.loginFormGroup.controls.fcUsername.invalid
      && (this.loginFormGroup.controls.fcUsername.dirty
        || this.loginFormGroup.controls.fcUsername.touched))
  }

  get validatePassword() {
    return (this.loginFormGroup.controls.fcPassword.invalid
      && (this.loginFormGroup.controls.fcPassword.dirty
        || this.loginFormGroup.controls.fcPassword.touched))
  }

  onSubmit() {
    this.identityClient.loginUser(this.getUsername, this.getPassword).subscribe(response => {
      if (response.HasError) {
        alert(response.Message);
      }
      else {
        this.store.setCredentials(response.Entity);
        this.institutionClient.getByAdminId(response.Entity.SystemUserId)
          .subscribe(response => {
            this.store.Institution = response.Entity;
          },
            dataError => {
              alert(dataError.error.Message);
            })
          
        if (UserRoles.Admin == <UserRoles>this.store.Credentials.Role) {
          this.router.navigate(['/admin-home']);
        }
      }
    }, error => {
      alert(error.error.Message);
    });
  }
}
