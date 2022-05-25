import { Component, OnInit } from '@angular/core';
import { BaseResponse } from '../../../entitites/BaseResponse';
import { Address } from '../../../entitites/responses/institution/Address';
import { Institution } from '../../../entitites/responses/institution/Institution';
import { InstitutionClientService } from '../../../http-client-services/institution.client.service';
import { ApplicationStoreService } from '../../../services/application.store.service';

@Component({
  selector: 'app-address-card',
  templateUrl: './address-card.component.html',
  styleUrls: ['./address-card.component.css']
})
export class AddressCardComponent implements OnInit {

  private defaultValue: string = '----------------------';
  public isCreatingAddress: boolean = false;
  public isUpdatingAddress: boolean = false;

  private address: Address;
  private institution: Institution;
  constructor(private httpClient: InstitutionClientService, private store: ApplicationStoreService) { }

  public address1: string = this.defaultValue;
  public address2: string = this.defaultValue;
  public city: string = this.defaultValue;
  public zip: string = this.defaultValue;
  public state: string = this.defaultValue;



  ngOnInit() {
    this.getInstitution();
    
  }

  hasAddress() {
    if (this.address != null)
      return true;
    else
      return false;
  }

  setCreateAddressForm(value: boolean) {
    this.getInstitution();
    if (this.institution) {
      this.isCreatingAddress = value;
      if (value == false)
        this.address1 = this.address2 = this.city = this.zip = this.state = this.defaultValue;
      else
        this.address1 = this.address2 = this.city = this.zip = this.state = "";
    }
    else {
      alert("No institution registered");
    }
    
  }

  setUpdateAddressForm(value: boolean) {
    this.isUpdatingAddress = value;
    this.address1 = this.address.Address1;
    this.address2 = this.address.Address2;
    this.city = this.address.City;
    this.zip = this.address.Zip;
    this.state = this.address.State;
  }


  createAddress() {
    this.isCreatingAddress = false;
    this.httpClient.createAddress(
      this.institution.Id,
      this.address1,
      this.address2,
      this.city,
      this.state,
      this.zip)
      .subscribe(response => {
        if (response.HasError) {
          alert(response.Message);
          //todo display error somewhere
        }
        else {
          this.address = response.Entity;
        }
      }, error => {
        alert(error.Message);
      });
  }

  updateAddress() {
    this.isUpdatingAddress = false;
    this.httpClient.updateAddress(
      this.institution.Id,
      this.address1,
      this.address2,
      this.city,
      this.state,
      this.zip)
      .subscribe(response => {
        if (response.HasError) {
          alert(response.Message);
          //todo display error somewhere
        }
        else {
          this.address = response.Entity;
          this.setAddressFormField();
        }
      }, error => {
        alert(error.Message);
      });
  }

  setAddressFormField() {
    this.address1 = this.address.Address1;
    this.address2 = this.address.Address2;
    this.city = this.address.City;
    this.state = this.address.State;
    this.zip = this.address.Zip;
  }
  getAddress() {
    this.httpClient.getAddressByInstitutionId(this.institution.Id)
      .subscribe(response => {
        if (!response.HasError) {
          this.address = response.Entity;
          this.setAddressFormField();
        }
      },
        error => {
          let errorResponse = error.error as BaseResponse;
          if (errorResponse.StatusCode = 404) {
          }
        }
      )
  }

  getInstitution() {
    this.httpClient.getByAdminId(this.store.Credentials.SystemUserId)
      .subscribe(response => {
        if (!response.HasError) {
          this.institution = response.Entity;
          this.getAddress();
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
