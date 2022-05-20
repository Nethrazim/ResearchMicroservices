import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-my-institution-page',
  templateUrl: './admin-my-institution-page.component.html',
  styleUrls: ['./admin-my-institution-page.component.css']
})
export class AdminMyInstitutionPageComponent implements OnInit {
  private pageTitle: string;

  private displayMenu: boolean = true;
  private displayManageInstitution: boolean = false;
  private displayManageAddress: boolean = false;
  private displayManageContacts: boolean = false;

  constructor() {
    this.pageTitle = "My Institution";
  }

  ngOnInit() {
  }

  ResetDisplayOptions() {
    this.displayManageInstitution = false;
    this.displayManageContacts = false;
    this.displayManageAddress = false;
  }

  Display(slug: string) {
    this.displayMenu = false;
    this.ResetDisplayOptions();
    switch (slug) {
      case "manage-institution":
        this.displayManageInstitution = true;
        break;
      case "manage-address":
        this.displayManageAddress = true;
        break;
      case "manage-contacts":
        this.displayManageContacts = true;
        break;
    }
  }

}
