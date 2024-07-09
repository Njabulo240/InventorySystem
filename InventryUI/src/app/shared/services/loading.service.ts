import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  loadingReqCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  loading() {
    this.loadingReqCount++;
    this.spinnerService.show(undefined, {
      type: 'ball-clip-rotate',
      bdColor : "rgba(0, 0, 0, 0.8)",
      color: '#fff',
      size:"medium",
    });
  }

  idle() {
    this.loadingReqCount--;
    if (this.loadingReqCount <= 0) {
      this.loadingReqCount = 0;
      this.spinnerService.hide();
    }
  }
}
