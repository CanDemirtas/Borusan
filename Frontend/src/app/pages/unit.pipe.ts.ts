import { Pipe, PipeTransform } from "@angular/core";
import { OrderStatus, WeightUnit } from "./order-page/order-page.component";

@Pipe({
    name: 'unitEnum',
})
export class UnitEnumPipe implements PipeTransform {
    transform(value: WeightUnit): any{
        return WeightUnit[value];
    }
}