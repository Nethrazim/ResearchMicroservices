import { Component, OnInit } from '@angular/core';
import { BaseResponse } from '../../../entitites/BaseResponse';
import { Institution } from '../../../entitites/responses/institution/Institution';
import { InstitutionClientService } from '../../../http-client-services/institution.client.service';
import { ApplicationStoreService } from '../../../services/application.store.service';

@Component({
  selector: 'app-institution-card',
  templateUrl: './institution-card.component.html',
  styleUrls: ['./institution-card.component.css']
})
export class InstitutionCardComponent implements OnInit {
  public hasInstitution: boolean = false;
  private defaultValue: string = '----------------------';
  public isCreatingInstitution: boolean = false;

  private institution: Institution;
  constructor(private httpClient: InstitutionClientService, private store: ApplicationStoreService) { }

  public institutionName: string = "";
  ngOnInit() {
    this.getInstitution();
  }

  getName() { return this.institution ? this.institution.Name : this.defaultValue; }
  getIsActive() { return this.institution ? this.institution.IsActive : this.defaultValue; }
  getCreationDate() { return this.institution ? this.institution.CreatedDate : this.defaultValue;  }

  setCreateInstitutionForm(value: boolean) { this.isCreatingInstitution = value; }
  getInstitution() {
    this.httpClient.getByAdminId(this.store.Credentials.SystemUserId)
      .subscribe(response => {
        if (!response.HasError) {
          this.institution = response.Entity;
          this.hasInstitution = true;
        }
      },
      error => {
        let errorResponse = error.error as BaseResponse;
        if (errorResponse.StatusCode = 404) {
          this.hasInstitution = false;
        }
      }
    )
  }

}
