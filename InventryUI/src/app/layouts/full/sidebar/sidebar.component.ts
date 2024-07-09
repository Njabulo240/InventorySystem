import { Component, OnInit } from '@angular/core';
import { navItems } from './sidebar-data';
import { NavService } from 'src/app/shared/services/nav.service';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
})
export class SidebarComponent implements OnInit {
  navItems = navItems;

  constructor(public navService: NavService) { }

  ngOnInit(): void { }
}
