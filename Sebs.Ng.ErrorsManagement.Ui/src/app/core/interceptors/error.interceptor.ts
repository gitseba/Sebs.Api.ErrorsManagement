import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    /*Now, when we want to manage something that is an observable, we're going to be using the rxJS library to help us do so.
    And if we want to use any of the operators that are available inside our X, then we have to pipe them
    or use their pipe method that we get and we'll use pipe.
    And then we can do something with the observable that comes back.
    Now this pipe.
    Operator or method is something that we'll use whenever we need to manipulate or do something with an
    observable before we pass it back to any of our components.
    And inside the parentheses here, if we want to do something with an observable, then we have the opportunity to do so.
    Now, what we're interested in right now is catching the error that comes back from our API. */
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error) {
          if (error.status === 400) {
            if (error.error.errors) {
              throw error.error;
            } else {
              this.toastr.error(error.error.message, error.status.toString())
            }
          }
          if (error.status === 401) {
            this.toastr.error(error.error.message, error.status.toString())
          }
          if (error.status === 404) {
            this.router.navigateByUrl('/not-found');
          };
          if (error.status === 500) {
            const navigationExtras: NavigationExtras = {state: {error: error.error}};
            this.router.navigateByUrl('/server-error', navigationExtras);
          }
        }
        return throwError(() => new Error(error.message))
      })
    )
  }
}