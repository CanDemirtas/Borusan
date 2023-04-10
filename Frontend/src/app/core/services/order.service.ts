import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { OrderModel } from 'src/app/pages/order-page/order-page.component';

@Injectable({
    providedIn: 'root'
})

export class OrderService {

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        }),
    };

    constructor(private http: HttpClient) { }

    fetchOrders(employee: any): Observable<OrderModel> {
        return this.http
            .post<any>(
                "https://localhost:44311/api/Order" + '/FetchOrders',
                JSON.stringify(employee),
                this.httpOptions
            )
            .pipe(retry(1), catchError(this.handleError));
    }

    saveStatusOrder(list: any): Observable<OrderModel> {
        return this.http
            .post<any>(
                "https://localhost:44311/api/Order" + '/UpdateStatus',
                JSON.stringify(list),
                this.httpOptions
            )
            .pipe(retry(1), catchError(this.handleError));
    }


    handleError(error: any) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        } else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        window.alert(errorMessage);
        return throwError(() => {
            return errorMessage;
        });
    }
  
}