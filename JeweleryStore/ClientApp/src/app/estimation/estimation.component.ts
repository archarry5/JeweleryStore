import { Component } from '@angular/core'
import { FormBuilder, Validators } from '@angular/forms'
import { AuthService } from '../auth/auth.service';
import { UserService } from '../auth/user.service';

enum PrintOptions {
  Screen,
  File,
  Paper
};

@Component({
  templateUrl: './estimation.component.html'
})
export class EstimationComponent {
  form
  return: string = '';
  isPrivilegedUser: Boolean = false;
  userType: string = '';
  discountValue: number = 0;
  totalPrice: number;
  printOptions: PrintOptions;
  
  constructor(private fb: FormBuilder,
    private user: UserService) {
    console.log('In ctor');
    this.form = fb.group({
      goldPrice: ['', Validators.required],
      weight: ['', Validators.required]
    });

    this.user.getUserType().subscribe(res => {
      this.isPrivilegedUser = res as Boolean;
      this.userType = res == true ? 'Privileged' : 'Normal';
      if (this.isPrivilegedUser) {
        this.user.getDiscountPerc().subscribe(res => {
          this.discountValue = res as number;
        });
      }
    });
  }

  calculatePrice(input: any) {
    this.totalPrice = input.goldPrice * input.weight - this.discountValue;
  }

  print(option: PrintOptions) {
    if (option == PrintOptions.Screen) {

    }
  }
}


