import { SelectionModel } from "@angular/cdk/collections";
import { MatTableDataSource } from "@angular/material/table";
import {MatTable} from '@angular/material/table';
import { OrderService } from "src/app/core/services/order.service";
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {Component, ViewChild} from '@angular/core';
import { OrderStatusEditComponent } from "./order-status-edit/order-status-edit.component";

export interface OrderModel {
  CustomerOrderNumber: String;
  DepartureAddress: Date;
  DeliveryAddress: Date;
  Quantity: Number;
  QuantityUnit: Number;
  Weight: Number;
  WeightUnit: Number;
  Status: Number;
  Material: Material;
  Note: String;
  Id: String;
  CreatedBy: string
  CreatedDate: Date;
}
export interface Material {

}
export enum SelectType {
  single,
  multiple
}

export enum OrderStatus {
  Received,
  OnTheWay,
  AtDistributionCenter,
  OutForDelivery,
  Delivered,
  DeliveryFailed
}
export enum WeightUnit
{
    Kilogram,
    Ton,
    Pound,
    Other
}
@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.sass']
})
export class OrderPageComponent {

  @ViewChild(MatTable) table: MatTable<OrderModel> | undefined;

  displayedColumns: string[] = [
    "select",
    "CustomerOrderNumber",
    "DepartureAddress",
    "DeliveryAddress",
    "Quantity",
    "QuantityUnit",
    "Weight",
    "WeightUnit",
    "Status",
    "Material",
    "Note",
    "CreatedDate"
  ];

  selectType = [
    { text: "Single", value: SelectType.single },
    { text: "Multiple", value: SelectType.multiple }
  ];

  dataSource = new MatTableDataSource<OrderModel>([]);
  selection = new SelectionModel<OrderModel>(true, []);
  displayType = SelectType.multiple;

  constructor(private orderService: OrderService,public dialog: MatDialog) { }
  
  ngOnInit() {
    this.dialog.afterAllClosed.subscribe(
      () => {
        this.fetchOrders();
      }
    );
  this.fetchOrders();
  }

  fetchOrders(){
    this.orderService.fetchOrders(null).subscribe((data: any) => {
      this.dataSource.data =data;
    });
  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(OrderStatusEditComponent, {
      width: '500px',
      enterAnimationDuration,
      exitAnimationDuration,
      data:this.selection.selected
    });
  }
  selectHandler(row: OrderModel) {
    if (this.displayType == SelectType.single) {
      if (!this.selection.isSelected(row)) {
        this.selection.clear();
      }
    }
    this.selection.toggle(row);
  }

  onChange(typeValue: number) {
    this.displayType = typeValue;
    this.selection.clear();
  }

  addData() {

  }

  update() {
    
  }
}
