import { Routes } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { RolesComponent } from './roles/roles.component';
import { AddRoleComponent } from './roles/add-role/add-role.component';
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
import { UpdateRoleComponent } from './roles/update-role/update-role.component';

export const UiComponentsRoutes: Routes = [
  {
    path: '',
    children: [
      {path: 'users', component: UsersComponent,},
      {path: 'roles',component: RolesComponent, },
      { path: 'add-role', component: AddRoleComponent },
      { path: 'update-role/:id', component: UpdateRoleComponent },
      {path: 'brand',component: BrandComponent, },
      { path: 'add-brand', component: AddBrandComponent },
      { path: 'update-brand/:id', component: UpdateBrandComponent },
      {path: 'supplier',component: SupplierComponent, },
      { path: 'add-supplier', component: AddSupplierComponent },
      { path: 'update-supplier/:id', component: UpdateSupplierComponent },
      {path: 'category',component: CategoryComponent, },
      { path: 'add-category', component: AddCategoryComponent },
      { path: 'update-category/:id', component: UpdateCategoryComponent },
      {path: 'device',component: DeviceComponent, },
      { path: 'add-device', component: AddDeviceComponent },
      { path: 'update-device/:id', component: UpdateDeviceComponent },
    ],
  },
];
