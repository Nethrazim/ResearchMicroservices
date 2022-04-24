import { Component, OnInit } from '@angular/core';

export interface Contact {
  FirstName: string;
  LastName: string;
  Email: string;
  Phone: string;
}


@Component({
  selector: 'app-admin-manage-contacts',
  templateUrl: './admin-manage-contacts.component.html',
  styleUrls: ['./admin-manage-contacts.component.css']
})
export class AdminManageContactsComponent implements OnInit {
  private dataSource: Array<Contact>;
  private displayedColumns: string[] = ['FirstName', 'LastName', 'Email', 'Phone'];
  constructor() {
    this.dataSource = new Array<Contact>({ FirstName: 'Vlad', LastName: 'Branzei', Email: 'vlad.branzei@gmail.com', Phone: '0040755972205' },
      { FirstName: 'Loredana', LastName: 'Branzei', Email: 'loredana.branzei@gmail.com', Phone: '0040755972206' }
    );
  }

  ngOnInit() {
  }

}
