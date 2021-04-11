import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from '../core/marketplace-api/models/user.model';
import {map} from "rxjs/operators";
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private readonly USER_ID_KEY = 'userId';
  private readonly USERNAME = 'username';

  private readonly marketplaceApUrl = 'https://localhost:5001';
  get userId(): string {
    return localStorage.getItem(this.USER_ID_KEY);
  }

  get username(): string {
    return localStorage.getItem(this.USERNAME);
  }

  constructor(private http: HttpClient) { }

  login(username: string): Observable<UserModel> {
    const url = `${this.marketplaceApUrl}/User/login`;
    return this.http.post( url, {username} )
      .pipe ( map((resp: any) => {
        this.guardarStorage(resp.id, resp.username);
        return resp;
      }));
  }

  guardarStorage( id: string, username: string ) {
    localStorage.setItem(this.USER_ID_KEY, id);
    localStorage.setItem(this.USERNAME, username);
  }

  logout(): void{
    localStorage.removeItem(this.USER_ID_KEY);
    localStorage.removeItem(this.USERNAME);
  }

  isLoggedIn(): boolean {
    return !!this.userId;
  }
}
