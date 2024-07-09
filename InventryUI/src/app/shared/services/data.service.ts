import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private refreshTab1 = new Subject<void>();

  refreshTab1$ = this.refreshTab1.asObservable();

  triggerRefreshTab1() {
    this.refreshTab1.next();
  }
}
