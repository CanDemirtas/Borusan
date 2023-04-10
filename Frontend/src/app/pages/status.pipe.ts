import { Pipe, PipeTransform } from "@angular/core";
import { OrderStatus } from "./order-page/order-page.component";

@Pipe({
    name: 'statusEnum',
})
export class EnumToDescriptionPipe implements PipeTransform {
    transform(value: OrderStatus,): any{
        return OrderStatus[value];
    }
}