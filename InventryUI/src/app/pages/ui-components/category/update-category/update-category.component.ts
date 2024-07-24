import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Category } from 'src/app/_interface/inventory/category';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { RepositoryErrorHandlerService } from 'src/app/shared/services/repository-error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-update-category',
  templateUrl: './update-category.component.html',
  styleUrls: ['./update-category.component.css']
})
export class UpdateCategoryComponent implements OnInit {

  public categoryForm: FormGroup | any;
  public errorMessage: string = '';
  public bsModalRef?: BsModalRef;
  private categoryId: string | null = '';

  constructor(
    private repository: RepositoryService,
    private errorHandler: RepositoryErrorHandlerService,
    private router: Router,
    private modal: BsModalService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get('id');
    this.categoryForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)])
    });
    this.initializeForm();
  }

  private initializeForm = () => {
    if (this.categoryId) {
      this.repository.getData(`api/categories/${this.categoryId}`)
        .subscribe({
          next: (category: any) => {
            this.categoryForm = new FormGroup({
              name: new FormControl(category.name, [Validators.required, Validators.maxLength(60)])
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
    if (this.categoryForm.get(controlName).invalid && this.categoryForm.get(controlName).touched)
      return true;
    
    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.categoryForm.get(controlName).hasError(errorName))
      return true;
    
    return false;
  }

  updateCategory = (categoryFormValue: any) => {
    if (this.categoryForm.valid)
      this.executeCategoryUpdate(categoryFormValue);
  }

  private executeCategoryUpdate = (categoryFormValue: any) => {
    const updatedCategory: Category = {
      id: this.categoryId ? this.categoryId : '',
      name: categoryFormValue.name
    };

    const apiUrl = `api/categories/${this.categoryId}`;
    this.repository.update(apiUrl, updatedCategory)
      .subscribe({
        next: () => {
          const config: ModalOptions = {
            initialState: {
              modalHeaderText: 'Success Message',
              modalBodyText: `Category: ${updatedCategory.name} updated successfully`,
              okButtonText: 'OK'
            }
          };

          this.bsModalRef = this.modal.show(SuccessModalComponent, config);
          this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToCategoryList());
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
