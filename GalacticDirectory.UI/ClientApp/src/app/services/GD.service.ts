import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { People } from '../Models/People';


const endPointUrl: string = 'assets/data/smartphone.json';

@Injectable({
  providedIn: 'root'
})
export class GDService {

  AppUrl: string;
  peopleApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    this.AppUrl = environment.appUrl;
    this.peopleApiUrl = 'api/People/'
  }
  getPeopleDetails(): Observable<People[]> {
    return this.http.get<People[]>(this.AppUrl + this.peopleApiUrl)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getPeopleById(Id: number): Observable<People> {
    return this.http.get<People>(this.AppUrl + this.peopleApiUrl + Id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  savePeopleDetails(People): Observable<People> {
    return this.http.post<People>(this.AppUrl + this.peopleApiUrl, JSON.stringify(People), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updatePeopleDetails(postId: number, People): Observable<People> {
    return this.http.put<People>(this.AppUrl + this.peopleApiUrl + postId, JSON.stringify(People), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deletePeopleById(Id: number): Observable<People> {
    return this.http.delete<People>(this.AppUrl + this.peopleApiUrl + Id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
