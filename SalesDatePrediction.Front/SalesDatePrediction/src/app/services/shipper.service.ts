import { Injectable } from '@angular/core';
import { enviroment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Shipper } from '../models/shipper';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {
  private apiUrl = `${enviroment.apiUrl}/Shipper`;

  constructor(private http: HttpClient) { }

  getShippers(): Observable<Shipper[]> {
    return this.http.get<Shipper[]>(`${this.apiUrl}/GetShippers`);
  }
}
