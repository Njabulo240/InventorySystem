import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-office',
  templateUrl: './update-office.component.html',
  styleUrls: ['./update-office.component.css']
})
export class UpdateOfficeComponent implements OnInit {

  public officeForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  private officeId: string | null = '';

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.officeId = this.route.snapshot.paramMap.get('id');
    this.officeForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      location: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });
    this.initializeForm();
  }

  private initializeForm = () => {
    if (this.officeId) {
      this.repository.getData(`api/offices/${this.officeId}`)
        .subscribe({
          next: (office: any) => {
            this.officeForm = new FormGroup({
              name: new FormControl(office.name, [Validators.required, Validators.maxLength(60)]),
              location: new FormControl(office.location, [Validators.required, Validators.maxLength(100)])
            });
          },
          error: (err: HttpErrorResponse) => {
            this.errorHandler.handleError(err);
            this.errorMessage = this.errorHandler.errorMessage;
          }
        });
    }
  }

  validateControl = (controlName: string) => {
    if (this.officeForm.get(controlName).invalid && this.officeForm.get(controlName).touched)
      return true;
    
    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.officeForm.get(controlName).hasError(errorName))
      return true;
    
    return false;
  }

  updateOffice = (officeFormValue: any) => {
    if (this.officeForm.valid)
      this.executeOfficeUpdate(officeFormValue);
  }

  private executeOfficeUpdate = (officeFormValue: any) => {
    const updatedOffice: any = {
      id: this.officeId ? this.officeId : '',
      name: officeFormValue.name,
      location: officeFormValue.location
    };

    const apiUrl = `api/offices/${this.officeId}`;
    this.repository.update(apiUrl, updatedOffice)
      .subscribe({
        next: () => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Office: ${updatedOffice.name} updated successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToOfficeList());
        },
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  redirectToOfficeList = () => {
    this.router.navigate(['/ui-components/office']);
  }

}
