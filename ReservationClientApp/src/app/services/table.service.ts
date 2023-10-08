import { Injectable } from '@angular/core';
import { Table } from '../models/table';
import { HttpClient } from '@angular/common/http';
import { ListResponse } from '../concrete/list-response';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CustomerReservation } from '../models/customer-reservation';
import { ReservationResult } from '../models/reservation-result';
import { CreateCustomerCommand } from '../models/create-customer-command';

@Injectable({
  providedIn: 'root'
})
export class TableService  {
  private readonly apiUrl = `${environment.apiUrl}`;

  constructor(private http: HttpClient) { }

  getList(){
    return this.http
        .get<ListResponse<Table>>(`${this.apiUrl}/tables/?PageIndex=0&PageSize=100`, {observe: 'body'})
        .pipe(
            map((x)=> {
                return x;
            })
        );
  }

  getById(id: number){
    return this.http
        .get<Table>(`${this.apiUrl}/tables/${id}`, {observe: 'body'})
        .pipe(
            map((x)=> {
                return x;
            })
        );
  }

  sendReservation(reservation: CreateCustomerCommand){
    return this.http
        .post<ReservationResult>(`${this.apiUrl}/customerReservations`, reservation)
        .pipe(
            map((x)=> {
                return x;
            })
        );
  }
}
