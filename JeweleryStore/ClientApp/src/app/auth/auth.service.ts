import { Injectable } from '@angular/core';
import { HttpClient, } from '@angular/common/http';
import { Router } from '@angular/router';
import { StorageService } from '../utilities/storage.service';

@Injectable()
export class AuthService {

  constructor(private http: HttpClient, private router: Router, private storage: StorageService) { }

  get isAuthenticated() {
    return this.storage.getItem('token');
  }

  login(credentials) {
    this.http.post<any>(`https://localhost:44315/api/account/login`, credentials).subscribe(res => {
      this.authenticate(res.token);
    })
  }

  authenticate(res) {
    this.storage.setItem('token', res);
  }

  logout() {
    this.storage.remove('token');
  }
}
