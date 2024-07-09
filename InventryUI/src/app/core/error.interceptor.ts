import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, catchError, throwError } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
export class ErrorInterceptor implements HttpInterceptor{
    constructor(private router: Router) { }
    
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
      catchError(error => {
        if(error){
            if(error.status === 400){
                this.router.navigate(['/404']);
            }
        }
        return throwError(error);

      })
    );
    }

}