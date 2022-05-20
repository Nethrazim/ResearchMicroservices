import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { InstitutionClientService } from '../../../http-client-services/institution.client.service';

@Component({
  selector: 'app-delete-institution',
  templateUrl: './delete-institution.component.html',
  styleUrls: ['./delete-institution.component.css']
})
export class DeleteInstitutionComponent implements OnInit {
  @Input() institutionId: number;
  @Output() deleteInstitution: EventEmitter<boolean>;
  constructor(private institutionClient: InstitutionClientService) {
    this.deleteInstitution = new EventEmitter<boolean>();
  }

  ngOnInit() {
  }

  onYes() {
    this.deleteInstitutionHandler(); 
  }

  onNo() {
    this.deleteInstitution.emit(false);
  }

  deleteInstitutionHandler() {
    this.institutionClient.deleteInstitution(this.institutionId)
      .subscribe(response => {
        if (response.HasError) {
          alert(response.Message);
          //todo display error somewhere
        }
        else {
          this.deleteInstitution.emit(true);
        }
      }, error => {
        //todo display error somewhere
      });
  }

}
