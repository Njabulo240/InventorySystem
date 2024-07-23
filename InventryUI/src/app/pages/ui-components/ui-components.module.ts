import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material.module';
import { TablerIconsModule } from 'angular-tabler-icons';
import * as TablerIcons from 'angular-tabler-icons/icons';
import { UiComponentsRoutes } from './ui-components.routing';
import { MatNativeDateModule } from '@angular/material/core';
import { UsersComponent } from './users/users.component';
import { RolesComponent } from './roles/roles.component';
import { ToastrModule } from 'ngx-toastr';
import { AddUserComponent } from './users/add-user/add-user.component';
import { UpdateUserComponent } from './users/update-user/update-user.component';
import { AddRoleComponent } from './roles/add-role/add-role.component';
import { UpdateRoleComponent } from './roles/update-role/update-role.component';
import { BrandComponent } from './brand/brand.component';
import { AddBrandComponent } from './brand/add-brand/add-brand.component';
import { UpdateBrandComponent } from './brand/update-brand/update-brand.component';
import { SupplierComponent } from './supplier/supplier.component';
import { AddSupplierComponent } from './supplier/add-supplier/add-supplier.component';
import { UpdateSupplierComponent } from './supplier/update-supplier/update-supplier.component';
import { CategoryComponent } from './category/category.component';
import { AddCategoryComponent } from './category/add-category/add-category.component';
import { UpdateCategoryComponent } from './category/update-category/update-category.component';
import { DeviceComponent } from './device/device.component';
import { AddDeviceComponent } from './device/add-device/add-device.component';
import { UpdateDeviceComponent } from './device/update-device/update-device.component';
import { UpdateUserRoleComponent } from './users/update-user-role/update-user-role.component';
import { EmployeeComponent } from './employee/employee.component';
import { AddEmployeeComponent } from './employee/add-employee/add-employee.component';
import { UpdateEmployeeComponent } from './employee/update-employee/update-employee.component';
import { OfficeComponent } from './office/office.component';
import { AddOfficeComponent } from './office/add-office/add-office.component';
import { UpdateOfficeComponent } from './office/update-office/update-office.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(UiComponentsRoutes),
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    TablerIconsModule.pick(TablerIcons),
    MatNativeDateModule,
    ToastrModule.forRoot({
      timeOut: 3000, 
      positionClass: 'toast-top-right', 
      preventDuplicates: true, 
      progressBar: true, 
      closeButton: true 
    }),
  ],
  declarations: [
    UsersComponent,
    RolesComponent,
    AddUserComponent,
    UpdateUserComponent,
    AddRoleComponent,
    UpdateRoleComponent,
    BrandComponent,
    AddBrandComponent,
    UpdateBrandComponent,
    SupplierComponent,
    AddSupplierComponent,
    UpdateSupplierComponent,
    CategoryComponent,
    AddCategoryComponent,
    UpdateCategoryComponent,
    DeviceComponent,
    AddDeviceComponent,
    UpdateDeviceComponent,
    UpdateUserRoleComponent,
    EmployeeComponent,
    AddEmployeeComponent,
    UpdateEmployeeComponent,
    OfficeComponent,
    AddOfficeComponent,
    UpdateOfficeComponent
    
  ],
})
export class UicomponentsModule {}
