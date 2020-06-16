import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private httpClient: HttpClient) { }

  getCountriesUrl = 'http://localhost:5000/api/countries/names';

  getCountries() {
    return this.httpClient.get(this.getCountriesUrl);
  }

  getStatesUrl = 'http://localhost:5000/api/states';

  getStates() {
    return this.httpClient.get(this.getStatesUrl);
  }
}