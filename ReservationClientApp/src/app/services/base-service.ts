import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { ListResponse } from '../concrete/list-response';

@Injectable({
  providedIn: 'root'
})

export class BaseService<T> {

    private readonly apiUrl = `${environment.apiUrl}`;

    constructor(private http: HttpClient) { }

    sendData(url: string, body?: any){
        return this.http
        .post<T>(url, body)
        .pipe(
            map((x)=> {
                return x;
            })
        );
    }

    getData(url: string){
        return this.http.get<T>(url).pipe(
            map((x)=> {
                return x;
            })
        );
    }

    getAllData(url: string){
        return this.http.get<ListResponse<T[]>>(url).pipe(
            map((x)=> {
                return x;
            })
        );
    }

    putData(url: string, body?: any){
        return this.http
        .post<T>(url, body)
        .pipe(
            map((x)=> {
                return x;
            })
        );
    }
}
