import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CreateReservationComponent } from 'src/create-reservation/create-reservation.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { TableService } from './services/table.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [	
    AppComponent,
    CreateReservationComponent
   ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: CreateReservationComponent, pathMatch: 'full' },
      { path: 'reservation', component: CreateReservationComponent, pathMatch: 'full' },
    ])
  ],
  providers: [TableService],
  bootstrap: [AppComponent]
})
export class AppModule { }
