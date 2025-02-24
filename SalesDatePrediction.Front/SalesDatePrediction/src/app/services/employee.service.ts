import { Injectable } from '@angular/core';
import { enviroment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = `${enviroment.apiUrl}/Employee`;

      constructor(private http: HttpClient) {}

      GetEmployees(): Observable<Employee[]> {
        return this.http.get<Employee[]>(`${this.apiUrl}/GetEmployees`);
      }
}
