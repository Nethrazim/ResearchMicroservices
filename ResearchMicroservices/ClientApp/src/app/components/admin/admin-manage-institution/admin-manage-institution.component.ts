import { Component, OnInit } from '@angular/core';
import { BaseResponse } from '../../../entitites/BaseResponse';
import { Institution } from '../../../entitites/responses/institution/Institution';
import { InstitutionClientService } from '../../../http-client-services/institution.client.service';
import { ApplicationStoreService } from '../../../services/application.store.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { CreateInstitutionComponent } from '../../create-institution/create-institution.component';

@Component({
  selector: 'app-admin-manage-institution',
  templateUrl: './admin-manage-institution.component.html',
  styleUrls: ['./admin-manage-institution.component.css']
})
export class AdminManageInstitutionComponent implements OnInit {
  public hasInstitution: boolean = false;
  public institutions: Institution[];
  private displayedColumns: string[] = ['Name', 'IsActive', 'UpdatedDate', 'CreatedDate', 'action'];

  constructor(private httpClient: InstitutionClientService, private store: ApplicationStoreService, public dialog: MatDialog) {
    
  }

  ngOnInit() {
    this.getInstitution();
  }


  getInstitution() {
    this.httpClient.getByAdminId(this.store.Credentials.SystemUserId)
      .subscribe(response => {
        if (!response.HasError) {
          this.institutions = [];
          this.institutions.push(response.Entity);
          this.hasInstitution = true;
        }
      },
        error => {
          let errorResponse = error.error as BaseResponse;
          if (errorResponse.StatusCode = 404) {
            this.hasInstitution = false;
            alert(errorResponse.Message);
          }
        }
      )
  }

  onOpenDialog(action: string, element: Institution) {
    if (action == 'Add') {
      let dialogConfig = new MatDialogConfig();
      dialogConfig.autoFocus = true;
      const dialogRef = this.dialog.open(CreateInstitutionComponent, dialogConfig);
      dialogRef.componentInstance.institutionCreated.subscribe((data) => {
        this.onInstitutionCreated(data);
      });
    }

    if (action == 'Edit') {
      alert("Edit Institution with ID = " + element.Id);
    }

    if (action == 'Delete') {
      alert("Delete Institution with ID = " + element.Id);
    }
  }

  onInstitutionCreated(result: boolean) {
    if (result) {
      this.getInstitution();
      this.dialog.closeAll();
    }
    else {
      alert("Institution NOT CREATED");
    }
  }
}
