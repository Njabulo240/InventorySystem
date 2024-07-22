import { NavItem } from './nav-item/nav-item';

export const navItems: NavItem[] = [
  {
    displayName: 'Dashboard',
    iconName: 'layout-dashboard',
    route: '/dashboard',
  },
  {
    displayName: 'Inventory items',
    iconName: 'list',
    children: [
      {
        displayName: 'Devices',
        iconName: 'devices',
        route: '/ui-components/device',
      },
      {
        displayName: 'Category',
        iconName: 'rosette',
        route: '/ui-components/category',
      },
      {
        displayName: 'Brand',
        iconName: 'list',
        route: '/ui-components/brand',
      },
      {
        displayName: 'Suppliers',
        iconName: 'calendar',
        route: '/ui-components/supplier',
      },
    ],
  },
  {
    displayName: 'User Management',
    iconName: 'user',
    children: [
      {
        displayName: 'Roles',
        iconName: 'user-check',
        route: '/ui-components/roles',
      },
      {
        displayName: 'User',
        iconName: 'user-check',
        route: '/ui-components/user',
      },
    ],
  },

  {
    displayName: 'Device Assignment',
    iconName: 'devices',
    children: [
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
    ],
  },

  {
    displayName: 'Employee and Office',
    iconName: 'building',
    children: [
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
    ],
  },

  {
    displayName: 'Asset Management',
    iconName: 'settings',
    children: [
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
    ],
  },

];
