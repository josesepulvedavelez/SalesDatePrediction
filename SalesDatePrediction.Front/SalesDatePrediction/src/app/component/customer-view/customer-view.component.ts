import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { CustomerViewService } from '../../services/customer-view.service';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { CustomerView } from '../../models/CustomerView';
import { MatDialog } from '@angular/material/dialog';
import { ModalClientOrdersComponent } from '../../modal-client-orders/modal-client-orders.component';
import { MatButtonModule } from '@angular/material/button';
import { OrderDto } from '../../models/OrderDto';
import { NewOrderModalComponent } from '../../new-order-modal/new-order-modal.component';
@Component({
  selector: 'app-customer-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    ModalClientOrdersComponent,
    NewOrderModalComponent,
    MatButtonModule,
  ],
  templateUrl: './customer-view.component.html',
})
export class CustomerComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'companyname',
    'lastOrderDate',
    'nextPredictedOrder',
    'actions',
  ];
  dataSource = new MatTableDataSource<CustomerView>();
  dataSourceOrders: OrderDto[] = [];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private customerViewService: CustomerViewService,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.loadCustomers();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  loadCustomers() {
    this.customerViewService.getAll().subscribe({
      next: (data) => {
        this.dataSource.data = data;
      },
      error: (error) => {
        console.error('Error al cargar los clientes', error);
      },
      complete: () => {
        console.log('Carga de clientes completada');
      },
    });
  }
  openModal(cusId: number, companyname: string): void {
    this.customerViewService.getClientOrders(cusId).subscribe({
      next: (data) => {
        this.dataSourceOrders = data;
        this.dialog.open(ModalClientOrdersComponent, {
          width: '940px',
          data: { orders: this.dataSourceOrders, companyname },
        });
      },
      error: (error) => {
        console.error('Error al cargar los clientes', error);
      },
      complete: () => {
        console.log('Carga de clientes completada');
      },
    });
  }
  openNewOrderModal(): void {
    this.dialog.open(NewOrderModalComponent, {
      width: '600px',
    });
  }
}
