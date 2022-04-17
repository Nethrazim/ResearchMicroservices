import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdentityClientService } from '../http-client-services/identity.client.service';
import { ApplicationStoreService } from '../services/application.store.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  username: string = ""
  email: string = "";
  password: string = "";
 
  constructor(private identityClient: IdentityClientService,
    private store: ApplicationStoreService
    , private router: Router
  )
  {
  }
  
  ngOnInit() {
  }

  onLogin() {
    this.identityClient.loginUser(this.username, this.email, this.password).subscribe(response => {
      if (response.HasError) {
        alert(response.Message);
      }
      else {
        this.store.JwtToken = response.Entity.TokenValue;
        this.store.Email = response.Entity.Email;
        this.store.Username = response.Entity.Username;
        this.store.TokenExpiresOn = response.Entity.Expires;
        alert(response.Message);
        this.router.navigate(['/register']);
      }
    }, error => {
      alert(error);
    });
  }
}
