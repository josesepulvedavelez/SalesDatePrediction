import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { enviroment } from '../../environments/environment';
import { CustomerView } from '../models/CustomerView';
import { OrderDto } from '../models/OrderDto';

@Injectable({
  providedIn: 'root',
})
export class CustomerViewService {
  private apiUrl = `${enviroment.apiUrl}/CustomerView`; // URL de tu API

  constructor(private http: HttpClient) {}

  getAll(): Observable<CustomerView[]> {
    return this.http.get<CustomerView[]>(`${this.apiUrl}/GetAll`);
  }

  getClientOrders(cusId: number): Observable<OrderDto[]> {    
    return this.http.get<OrderDto[]>(`${this.apiUrl}/GetClientOrders/${cusId}`);
  }
}