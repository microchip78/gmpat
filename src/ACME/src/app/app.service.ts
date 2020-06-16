import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  constructor(private http: HttpClient) {}

  getCountryNames(): Observable<string[]> {
    return this.http.get<string[]>('/api/countries/names');
  }

  getStates(): Observable<string[]> {
    return this.http.get<string[]>('/api/states');
  }

  getValidatePostcode(state: string, postcode: string): Observable<boolean> {
    return this.http
      .get<string[]>(`/api/Postcodes/${state}`)
      .pipe(map((result) => result.indexOf(postcode) >= 0));
  }

  postApplicationForm(form: any): Observable<number> {
    const body = {
      CountryName: form.country,
      FullName: form.fullname,
      Postcode: form.postcode,
    };
    return this.http.post<number>('/api/Submit/application', body);
  }
}
