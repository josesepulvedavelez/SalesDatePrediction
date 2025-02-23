import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MatDialogRef,
  MatDialogContent,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
@Component({
  selector: 'app-modal-client-orders',
  imports: [MatFormFieldModule,
    MatButtonModule,
    MatToolbarModule,
    MatDialogContent,
    MatTableModule
  ],
  templateUrl: './modal-client-orders.component.html',
  styleUrl: './modal-client-orders.component.css'
})
export class ModalClientOrdersComponent {
  constructor(
    public dialogRef: MatDialogRef<ModalClientOrdersComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    console.log(this.data);
   }

  close(): void {
    this.dialogRef.close();
  }

}
