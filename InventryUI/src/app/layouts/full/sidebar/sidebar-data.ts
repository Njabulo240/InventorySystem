import { NavItem } from './nav-item/nav-item';

export const navItems: NavItem[] = [
  {
    navCap: 'Home',
  },
  {
    displayName: 'Dashboard',
    iconName: 'layout-dashboard',
    route: '/dashboard',
  },
  {
    navCap: 'Inventory Management',
  },
  {
    displayName: 'Devices',
    iconName: 'devices',
    route: '/inventory/devices',
  },
  {
    displayName: 'Category',
    iconName: 'rosette',
    route: '/inventory/category',
  },
  {
    displayName: 'Brand',
    iconName: 'list',
    route: '/inventory/brand',
  },
  {
    displayName: 'Suppliers',
    iconName: 'storefront',
    route: '/inventory/suppliers',
  },
  {
    navCap: 'User Management',
  },
  {
    displayName: 'User',
    iconName: 'user-check',
    route: '/user-management/user',
  },
  {
    navCap: 'Device Assignment',
  },
  {
    displayName: 'Assign Devices',
    iconName: 'device-hub',
    route: '/device-assignment/assign',
  },
  {
    displayName: 'Assigned Devices',
    iconName: 'assignment',
    route: '/device-assignment/list',
  },

  {
    navCap: 'Employee and Office',
  },
  {
    displayName: 'Employees',
    iconName: 'users',
    route: '/employee-office/employees',
  },
  {
    displayName: 'Offices',
    iconName: 'building',
    route: '/employee-office/offices',
  },
  {
    navCap: 'Asset Management',
  },
  {
    displayName: 'Maintenance',
    iconName: 'calendar',
    route: '/asset-management/maintenance',
  },
  {
    displayName: 'Service History',
    iconName: 'history',
    route: '/asset-management/service-history',
  },
  {
    displayName: 'Faulty Devices',
    iconName: 'alert-triangle',
    route: '/inventory/faulty-devices',
  },
  {
    navCap: 'Reports and Analytics',
  },
  {
    displayName: 'Reports',
    iconName: 'bar-chart',
    route: '/reports',
  },
];
