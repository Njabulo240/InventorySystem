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
    navCap: 'Products',
  },
  {
    displayName: 'Product',
    iconName: 'poker-chip',
    route: '/ui-components/roles',
  },
  {
    displayName: 'Category',
    iconName: 'rosette',
    route: '/ui-components/users',
  },

  {
    displayName: 'Brand',
    iconName: 'list',
    route: '/ui-components/lists',
  },
  {
    navCap: 'User Management',
  },
  {
    displayName: 'User list',
    iconName: 'poker-chip',
    route: '/ui-components/roles',
  },
  {
    displayName: 'Role',
    iconName: 'poker-chip',
    route: '/ui-components/roles',
  },
  {
    navCap: 'Report',
  },
  {
    displayName: 'Product Report',
    iconName: 'poker-chip',
    route: '/ui-components/roles',
  }
];
