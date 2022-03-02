import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { user } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  constructor(private http: HttpClient) { }

  getUser(id: string): Observable<user> {
    return this.http.get<user>(`${environment.url}Users/${id}`);
  }

  getList(): Observable<user[]> {
    return this.http.get<user[]>(environment.url + "Users");
  }
  search(role: number, name: string): Observable<user[]> {
    return this.http.get<user[]>(`${environment.url}Users/${role}/${name}`);
  }
  AddUser(user: user): Observable<boolean> {
    user.roleCode = Number(user.roleCode);
    return this.http.post<boolean>(`${environment.url}Users`, user);
  }

}
