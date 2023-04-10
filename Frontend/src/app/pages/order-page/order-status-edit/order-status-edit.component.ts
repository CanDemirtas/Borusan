import { Component } from '@angular/core';
import { Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { OrderService } from 'src/app/core/services/order.service';


@Component({
  selector: 'app-order-status-edit',
  templateUrl: './order-status-edit.component.html',
  styleUrls: ['./order-status-edit.component.sass']
})
export class OrderStatusEditComponent {

  orderData: any;
  selectedStatus: string = "0";

  selectedStatusControl = new FormControl(this.selectedStatus);

  constructor(
    public dialogRef: MatDialogRef<OrderStatusEditComponent>,
    private orderService: OrderService,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.orderData = data;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  saveOrderStatus() {
    console.log("123"+this.orderData.map((a: any) => { a.Status = this.selectedStatusControl.value; return a; }));
    this.orderService.saveStatusOrder(this.orderData.map((a:any) => { a.Status = Number(this.selectedStatus); return a; })).subscribe((data: any) => {
      this.dialogRef.close();
    });

  }

}
