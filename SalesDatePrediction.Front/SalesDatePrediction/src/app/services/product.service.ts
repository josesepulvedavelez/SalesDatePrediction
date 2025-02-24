import { Injectable } from '@angular/core';
import { enviroment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = `${enviroment.apiUrl}/Product`;

    constructor(private http: HttpClient) {}

    getProducts(): Observable<Product[]> {
      return this.http.get<Product[]>(`${this.apiUrl}/GetProducts`);
    }
}
