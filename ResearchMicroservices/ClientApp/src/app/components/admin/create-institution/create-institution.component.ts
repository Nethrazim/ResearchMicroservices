import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { InstitutionClientService } from '../../../http-client-services/institution.client.service';
import { ApplicationStoreService } from '../../../services/application.store.service';

@Component({
  selector: 'app-create-institution',
  templateUrl: './create-institution.component.html',
  styleUrls: ['./create-institution.component.css']
})
export class CreateInstitutionComponent implements OnInit {
  createInstitutionFormGroup: FormGroup;
  name: string = "";

  @Output() institutionCreated: EventEmitter<boolean>;
  constructor(private institutionClient: InstitutionClientService,
    private store: ApplicationStoreService)
  {
    this.institutionCreated = new EventEmitter<boolean>();
  }

  ngOnInit() {
    this.createInstitutionFormGroup = new FormGroup({
      fcName: new FormControl(this.name, [Validators.required])
    });  
  }

  getName() { return this.createInstitutionFormGroup.get('fcName').value; }

  get validateName() {
    return (this.createInstitutionFormGroup.controls.fcName.invalid
      && (this.createInstitutionFormGroup.controls.fcName.dirty
      || this.createInstitutionFormGroup.controls.fcName.touched))
  }

  onSubmit() {
    this.institutionClient.createInstitution(this.store.Credentials.SystemUserId, this.getName())
      .subscribe(response => {
        if (response.HasError) {
          alert(response.Message);
          //todo display error somewhere
        }
        else {
          this.institutionCreated.emit(true);
        }
      }, error => {
        //todo display error somewhere
      });
  }
}
