import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Category } from 'src/app/_interface/inventory/category';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  public categoryForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService
  ) { }

  ngOnInit(): void {
    this.categoryForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)])
    });
  }

  validateControl = (controlName: string) => {
    if (this.categoryForm.get(controlName).invalid && this.categoryForm.get(controlName).touched)
      return true;
    
    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.categoryForm.get(controlName).hasError(errorName))
      return true;
    
    return false;
  }

  createCategory = (categoryFormValue: any) => {
    if (this.categoryForm.valid)
      this.executeCategoryCreation(categoryFormValue);
  }

  private executeCategoryCreation = (categoryFormValue: any) => {
    const category: any = {
      name: categoryFormValue.name
    };

    const apiUrl = 'api/categories';
    this.repository.create(apiUrl, category)
      .subscribe({
        next: (createdCategory: any) => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Category: ${createdCategory.name} created successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe((_: any) => this.redirectToCategoryList());
        },
        error: (err: HttpErrorResponse) => {
          this.errorHandler.handleError(err);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      });
  }

  redirectToCategoryList = () => {
    this.router.navigate(['/ui-components/category']);
  }
}
