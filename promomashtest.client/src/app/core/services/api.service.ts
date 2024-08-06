import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Country } from '../models/Country';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'https://localhost:7055/api';

  constructor(private http: HttpClient) { }

  getCountries(): Observable<Country[]> {
    console.log('getCountries');
    return this.http.get<Country[]>(`${this.baseUrl}/countries`);
  }

  getCountry(id: number): Observable<Country> {
    return this.http.get<Country>(`${this.baseUrl}/countries/${id}`);
  }

  registerUser(user: User): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/users`, user);
  }
}
