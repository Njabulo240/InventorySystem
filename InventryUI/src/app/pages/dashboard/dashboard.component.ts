import {
  Component,
  ViewEncapsulation,
} from '@angular/core';
import {
  MonthDto,
  MonthTotalDto,
  AuditLogDto,
} from 'src/app/_interface/audit-log';
import {
  salesOverviewChart,
} from 'src/app/_interface/chart';
import { CustomerDto } from 'src/app/_interface/customers';
import { UserDto } from 'src/app/_interface/user';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class AppDashboardComponent {

  constructor(private repoService: RepositoryService) { }

  ngOnInit() {

  }

 
}
