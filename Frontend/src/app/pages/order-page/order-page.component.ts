import { SelectionModel } from "@angular/cdk/collections";
import { Component, OnInit } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";
import { FormControl } from "@angular/forms";
import { OrderService } from "src/app/core/services/order.service";

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

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.sass']
})
export class OrderPageComponent {
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

  constructor(private orderService: OrderService) { }
  dataa: any;
  ngOnInit() {

    this.orderService.fetchOrders(null).subscribe((data: any) => {
      this.dataa = data;
      this.dataSource.data =data;

      console.log("can:" + JSON.stringify(data));
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
}
