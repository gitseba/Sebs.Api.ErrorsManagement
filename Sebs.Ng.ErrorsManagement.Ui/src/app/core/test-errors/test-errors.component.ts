import { Component } from '@angular/core';
import { environment } from 'src/env/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent {
  baseUrl = environment.apiUrl;
  validationErrors: string[] = [];

  constructor(private http: HttpClient) {}

  get404Error() {
    this.http.get(this.baseUrl + 'errorGenerator/42').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get500Error() {
    this.http.get(this.baseUrl + 'errorGenerator/servererror').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get400Error() {
    this.http.get(this.baseUrl + 'errorGenerator/badrequest').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get400ValidationError() {
    this.http.get(this.baseUrl + 'errorGenerator/badrequest/fortytwo').subscribe({
      next: response => console.log(response),
      error: error => {
        console.log(error);
        this.validationErrors = error.errors;
      }
    })
  }
}