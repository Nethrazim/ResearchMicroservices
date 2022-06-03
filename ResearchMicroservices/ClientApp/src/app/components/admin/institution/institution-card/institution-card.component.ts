import { Component, OnInit } from '@angular/core';
import { BaseResponse } from '../../../../entitites/BaseResponse';
import { Institution } from '../../../../entitites/responses/institution/Institution';
import { InstitutionClientService } from '../../../../http-client-services/institution.client.service';
import { ApplicationStoreService } from '../../../../services/application.store.service';

@Component({
  selector: 'app-institution-card',
  templateUrl: './institution-card.component.html',
  styleUrls: ['./institution-card.component.css']
})
export class InstitutionCardComponent implements OnInit {
  private defaultValue: string = '----------------------';
  public isCreatingInstitution: boolean = false;
  public isUpdatingInstitution: boolean = false;

  private institution: Institution;
  constructor(private httpClient: InstitutionClientService, private store: ApplicationStoreService) { }

  public institutionName: string = "";
  ngOnInit() {
    this.getInstitution();
  }

  hasInstitution() {
    if (this.institution != null)
      return true;
    else
      return false;
  }

  getName() { return this.institution ? this.institution.Name : this.defaultValue; }
  getIsActive() { return this.institution ? this.institution.IsActive : this.defaultValue; }
  getCreationDate() { return this.institution ? this.institution.CreatedDate : this.defaultValue;  }

  setCreateInstitutionForm(value: boolean) { this.isCreatingInstitution = value; }
  setUpdateInstitutionForm(value: boolean) {
    this.isUpdatingInstitution = value;
    this.institutionName = this.institution.Name;
  }


  createInstitution() {
    this.isCreatingInstitution = false;
    this.httpClient.createInstitution(this.store.Credentials.SystemUserId, this.institutionName)
      .subscribe(response => {
        if (response.HasError) {
          alert(response.Message);
          //todo display error somewhere
        }
        else {
          this.institution = response.Entity;
        }
      }, error => {
        alert(error.Message);
      });
  }

  updateInstitution() {
    this.isUpdatingInstitution = false;
    this.httpClient.updateInstitution(this.institution.Id, this.institutionName)
      .subscribe(response => {
        if (response.HasError) {
          alert(response.Message)
        }
        else {
          this.institution = response.Entity;
        }
      }, error => {
        alert(error.Message);
      })
  }

  getInstitution() {
    this.httpClient.getByAdminId(this.store.Credentials.SystemUserId)
      .subscribe(response => {
        if (!response.HasError) {
          this.institution = response.Entity;
        }
      },
      error => {
        let errorResponse = error.error as BaseResponse;
        if (errorResponse.StatusCode = 404) {
        }
      }
    )
  }

}
