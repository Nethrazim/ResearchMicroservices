import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Alert } from 'selenium-webdriver';
import { IdentityClientService } from '../../http-client-services/identity.client.service';


@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {
  username: "";

  email: "";

  password: "";

  confirmPassword: "";
  
  createFormGroup: FormGroup;

  constructor(private identityClient: IdentityClientService, private router: Router) { }

  ngOnInit() {
    this.createFormGroup = new FormGroup({
      username: new FormControl(this.username, [
        Validators.required,
        Validators.minLength(6)
      ]),
      email: new FormControl(this.email, [
        Validators.required,
        Validators.email
      ]),
      password: new FormControl(this.password, [
        Validators.required,
        Validators.minLength(12)
      ]),
      confirmPassword: new FormControl(this.confirmPassword, [
        Validators.required,
        Validators.minLength(12)
      ]),
    }); 
  }

  get formControls() {
    return this.createForm.controls;
  }

  get createForm() {
    return this.createFormGroup;
  }

  get usernameInvalid()
  {
    return (this.formControls.username.invalid && (this.formControls.username.dirty || this.formControls.username.touched))
  }

  get emailInvalid()
  {
    return (this.formControls.email.invalid && (this.formControls.email.dirty || this.formControls.email.touched))
  }

  get passwordInvalid()
  {
    return (this.formControls.password.invalid && (this.formControls.password.dirty || this.formControls.password.touched))
  }

  get confirmPasswordInvalid()
  {
    return (this.formControls.confirmPassword.invalid && (this.formControls.confirmPassword.dirty || this.formControls.confirmPassword.touched))
  }

  get passwordsDoNotMatch() {
    return (((this.formControls.password.dirty || this.formControls.password.touched)
      || (this.formControls.confirmPassword.dirty || this.formControls.confirmPassword.touched))
      && this.formControls.password.value != this.formControls.confirmPassword.value);
  }

  onSubmit() {
    this.identityClient.createUser(this.username, this.email, this.password, 1).subscribe(
      response => {
        if (response.HasError) {
          alert(response.Message);
        }
        else {
          alert(response.Message);
          this.router.navigate(['/login']);
        }
      });
  }
   
}
