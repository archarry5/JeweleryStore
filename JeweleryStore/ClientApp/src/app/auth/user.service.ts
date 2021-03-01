import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserService {
  userName: string;
  isPrivileged: Boolean;

  constructor(private http: HttpClient) { }

  getUserType() {
    return this.http.get(`https://localhost:44315/api/user/isPrivileged`);
  }

  getDiscountPerc() {
    return this.http.get(`https://localhost:44315/api/user/getDiscountPerc`);
  }
}
