import { HttpErrorResponse } from '@angular/common/http';
import {
  Component,
  ViewEncapsulation,
} from '@angular/core';
import { DeviceCategoryReport } from 'src/app/_interface/inventory/device';

import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class AppDashboardComponent {

  deviceReports: DeviceCategoryReport[] = [];
  errorMessage: string = '';

  constructor(private repositoryService: RepositoryService) { }

  ngOnInit(): void {
    this.getDeviceCategoryReport();
  }



  public getDeviceCategoryReport = () => {
    const addressUri: string = `api/devices/count`;
    this.repositoryService.getData(addressUri)
    .subscribe(res => {
      this.deviceReports = res as DeviceCategoryReport[];
    },
    (error) => {
      this.errorMessage = error.message
    })
  }
 
}
