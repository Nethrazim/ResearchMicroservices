import { Component, OnInit } from '@angular/core';
import { BaseResponse } from '../../../entitites/BaseResponse';
import { Address } from '../../../entitites/responses/institution/Address';
import { Contact } from '../../../entitites/responses/institution/Contact';
import { Institution } from '../../../entitites/responses/institution/Institution';
import { InstitutionClientService } from '../../../http-client-services/institution.client.service';
import { ApplicationStoreService } from '../../../services/application.store.service';

@Component({
  selector: 'app-contact-card',
  templateUrl: './contact-card.component.html',
  styleUrls: ['./contact-card.component.css']
})
export class ContactCardComponent implements OnInit {
  private defaultValue: string = '----------------------';
  public isCreatingContact: boolean = false;
  public isUpdatingContact: boolean = false;

  private contact: Contact;
  private institution: Institution;
  constructor(private httpClient: InstitutionClientService, private store: ApplicationStoreService) { }

  public firstName: string = this.defaultValue;
  public lastName: string = this.defaultValue;
  public middleName: string = this.defaultValue;
  public email: string = this.defaultValue;
  public phone: string = this.defaultValue;



  ngOnInit() {
    this.getInstitution();

  }

  hasContact() {
    if (this.contact != null)
      return true;
    else
      return false;
  }

  setCreateContactForm(value: boolean) {
    this.getInstitution();
    if (this.institution) {
      this.isCreatingContact = value;
      if (value == false)
        this.firstName = this.middleName = this.lastName = this.email = this.phone = this.defaultValue;
      else
        this.firstName = this.middleName = this.lastName = this.email = this.phone = "";
    }
    else {
      alert("No institution registered");
    }

  }

  setUpdateContactForm(value: boolean) {
    this.isUpdatingContact = value;
    this.firstName = this.contact.FirstName;
    this.middleName = this.contact.MiddleName;
    this.email = this.contact.Email;
    this.phone = this.contact.Phone;
  }


  createContact() {
    this.isCreatingContact = false;
    this.httpClient.createContact(
      this.institution.Id,
      this.firstName,
      this.middleName,
      this.lastName,
      this.email,
      this.phone)
      .subscribe(response => {
        if (response.HasError) {
          alert(response.Message);
          //todo display error somewhere
        }
        else {
          this.contact = response.Entity;
        }
      }, error => {
        alert(error.Message);
      });
  }

  updateContact() {
    this.isUpdatingContact = false;
    this.httpClient.updateContact(
      this.institution.Id,
      this.firstName,
      this.middleName,
      this.lastName,
      this.email,
      this.phone)
      .subscribe(response => {
        if (response.HasError) {
          alert(response.Message);
          //todo display error somewhere
        }
        else {
          this.contact = response.Entity;
          this.setContactFormFields();
        }
      }, error => {
        alert(error.Message);
      });
  }

  setContactFormFields() {
    this.firstName = this.contact.FirstName;
    this.middleName = this.contact.MiddleName;
    this.lastName = this.contact.LastName;
    this.email = this.contact.Email;
    this.phone = this.contact.Phone;
  }

  getContact() {
    this.httpClient.getContactByInstitutionId(this.institution.Id)
      .subscribe(response => {
        if (!response.HasError) {
          this.contact = response.Entity;
          this.setContactFormFields();
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
          this.getContact();
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
