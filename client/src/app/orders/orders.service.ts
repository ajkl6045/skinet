import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUser } from '../shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  baseUrl = environment.apiUrl;
 // private currentUserSource = new ReplaySubject<IUser>(null);
// currentUser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient) { }

  getOrdersForUser() {
    return this.http.get(this.baseUrl + 'orders');
  }
  getOrdertailed(id: number) {
    return this.http.get(this.baseUrl + 'orders/' + id);
  }
}
