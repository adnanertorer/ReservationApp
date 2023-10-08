import { Component, OnInit } from '@angular/core';
import { CreateCustomerCommand } from 'src/app/models/create-customer-command';
import { CustomerReservation } from 'src/app/models/customer-reservation';
import { ErrorModel } from 'src/app/models/error-model';
import { Table } from 'src/app/models/table';
import { TableService } from 'src/app/services/table.service';

@Component({
  selector: 'app-create-reservation',
  templateUrl: './create-reservation.component.html',
  styleUrls: ['./create-reservation.component.css']
})
export class CreateReservationComponent implements OnInit  {
  title = 'IsSytem Reservation';
  model: CreateCustomerCommand | undefined;
  tables: Table[] = [];
  
  constructor(private tableService: TableService) { 
  }
  
  ngOnInit() {
    this.model = {
      customerReservation:{
        customerDto: {
          email: '',
          id: 0,
          name: '',
          phone: '',
          surname: ''
        },
        guestCount: 1,
        reservationEndDate: undefined,
        reservationStartDate: undefined,
        tableDto: {
          capacity: 0,
          id: 0,
          tableName: ''
        },
        tableId: 0
      }
    }
    this.getTableList();
  }

  getTableList(){
    this.tableService.getList().subscribe(data=>{
      this.tables = data.items;
    })
  }

  tableChange(event: any) {
    let id = parseInt(event.target.value);
   this.tableService.getById(id).subscribe(data=>{
      this.model!.customerReservation.tableId = id;
      this.model!.customerReservation.tableDto = data;
      console.log(this.model!);
   });
  }

  send(){
    this.tableService.sendReservation(this.model!).subscribe(res=>{
      alert('Rezervasyonunuz tamamlandı ve reservasyon bilgileriniz e-posta adresinize gönderidi.');
    }, (err)=>{
       let errResult = err.error as ErrorModel;
       if(errResult.status == 400){
        if(errResult.title === "Validation error(s)"){
          let errMsg = '';
          errResult.Errors?.forEach(item =>{
            item.Errors?.forEach(errorItem =>{
              errMsg += errorItem+'\n';
            });
          });
          alert(errMsg);
        }else{
          alert(errResult.detail);
        }
       
       }
    });
  }

}
