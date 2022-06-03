import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { InstitutionClientService } from '../../../../http-client-services/institution.client.service';

@Component({
  selector: 'app-update-institution',
  templateUrl: './update-institution.component.html',
  styleUrls: ['./update-institution.component.css']
})
export class UpdateInstitutionComponent implements OnInit {

  @Input() institutionName: string;
  @Input() institutionId: number;
  @Output() institutionUpdated: EventEmitter<boolean>;
  institutionFormGroup: FormGroup;

  name: string = "";
  constructor(private institutionClient : InstitutionClientService) {
    this.institutionUpdated = new EventEmitter<boolean>();
  }

  ngOnInit() {
    this.name = this.institutionName;
    this.institutionFormGroup = new FormGroup({
      fcName: new FormControl(this.name, [Validators.required])
    });
  }

  getName() { return this.institutionFormGroup.get('fcName').value; }

  get validateName() {
    return (this.institutionFormGroup.controls.fcName.invalid
      && (this.institutionFormGroup.controls.fcName.dirty
        || this.institutionFormGroup.controls.fcName.touched))
  }

  onSubmit() {
    this.institutionClient.updateInstitution(this.institutionId, this.getName())
      .subscribe(response => {
        if (response.HasError) {
          alert(response.Message);
          //todo display error somewhere
        }
        else {
          this.institutionUpdated.emit(true);
        }
      }, error => {
        //todo display error somewhere
      });
  }
}
