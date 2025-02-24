import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, Inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MatDialogRef,
  MatDialogContent,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { EmployeeService } from '../services/employee.service';
import { ProductService } from '../services/product.service';
import { ShipperService } from '../services/shipper.service';
import { Employee } from '../models/employee';
import { Product } from '../models/product';
import { Shipper } from '../models/shipper';
import { provideNativeDateAdapter } from '@angular/material/core';

@Component({
  selector: 'app-new-order-modal',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatButtonModule,
    MatToolbarModule,
    MatDialogContent,
    MatTableModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
  ],
  templateUrl: './new-order-modal.component.html',
  styleUrls: ['./new-order-modal.component.css'],
  providers: [provideNativeDateAdapter()],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NewOrderModalComponent implements OnInit {
  dataEmployees: Employee[] = [];
  dataProducts: Product[] = [];
  dataShippers: Shipper[] = [];

  constructor(
    public dialogRef: MatDialogRef<NewOrderModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private employeeService: EmployeeService,
    private productService: ProductService,
    private shipperService: ShipperService
  ) {
    console.log(this.data);
  }

  ngOnInit() {
    this.loadEmployees();
    this.loadProducts();
    this.loadShippers();
  }

  close(): void {
    this.dialogRef.close();
  }

  loadEmployees() {
    this.employeeService.GetEmployees().subscribe({
      next: (data) => {
        this.dataEmployees = data;
      },
      error: (error) => {
        console.error('Error al cargar los empleados', error);
      },
      complete: () => {
        console.log('Carga de empleados completada');
      },
    });
  }

  loadProducts() {
    this.productService.getProducts().subscribe({
      next: (data) => {
        this.dataProducts = data;
      },
      error: (error) => {
        console.error('Error al cargar los empleados', error);
      },
      complete: () => {
        console.log('Carga de empleados completada');
      },
    });
  }

  loadShippers() {
    this.shipperService.getShippers().subscribe({
      next: (data) => {
        this.dataShippers = data;
      },
      error: (error) => {
        console.error('Error al cargar los shippers', error);
      },
      complete: () => {
        console.log('Carga de shippers completada');
      },
    });
  }
}
