import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrderPageComponent } from './pages/order-page/order-page.component';
import { MaterialModule } from './core/services/material.module';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { HttpClientModule } from '@angular/common/http';
import { OrderService } from './core/services/order.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { OrderStatusEditComponent } from './pages/order-page/order-status-edit/order-status-edit.component';
import { EnumToDescriptionPipe } from './pages/status.pipe';
import { UnitEnumPipe } from './pages/unit.pipe.ts';

@NgModule({
  declarations: [
    AppComponent,
    OrderPageComponent,
    OrderStatusEditComponent,
    EnumToDescriptionPipe,
    UnitEnumPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    FlexLayoutModule
  ],
  exports:[EnumToDescriptionPipe,UnitEnumPipe],
  entryComponents: [OrderPageComponent],
  providers: [{ provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } },OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
