import { Injectable } from '@angular/core';


@Injectable()
export class StorageService {

  getItem(name: string): any {
    return localStorage.getItem(name);
    
  }

  setItem(name: string, value: any) {
    localStorage.setItem(name, value);
  }

  remove(name: string) {
    localStorage.removeItem(name);
  }
}
