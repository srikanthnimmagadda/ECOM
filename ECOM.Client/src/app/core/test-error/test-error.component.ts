import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  baseUrl = environment.apiUrl;
  validationErrors: Array<any> = [];
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get404Error() {
    this.http.get(this.baseUrl + 'products/42').subscribe(response => {
      console.log(response);
    }, error => { console.log(error); });
  }

  get500Error() {
    this.http.get(this.baseUrl + 'buggy/servererror').subscribe(response => {
      console.log(response);
    }, error => { console.log(error); });
  }

  get400Error() {
    this.http.get(this.baseUrl + 'buggy/badrequest').subscribe(response => {
      console.log(response);
    }, error => { console.log(error); });
  }

  // subscribe new format for the old deprecated
  get400ValidationError() {
    this.http.get(this.baseUrl + 'products/one').subscribe({

      next: (response) => {
        console.log(response);
      },

      error: (error) => {
        console.log(error);
        for (let [key, value] of Object.entries(error.errors)) {
          this.validationErrors.push(value[0]);
        }
        //this.validationErrors = error.errors;
      },

      complete: () => console.info('complete')
    })
  }
}
