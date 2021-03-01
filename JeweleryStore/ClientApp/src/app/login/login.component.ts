import { Component } from '@angular/core'
import { FormBuilder, Validators } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { UserService } from '../auth/user.service';

@Component({
  templateUrl: './login.component.html'
})
export class LoginComponent {
  form
  return: string = '';

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private router: Router, private auth: AuthService, private user: UserService) {
    this.form = fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit() {
    // Get the query params
    this.route.queryParams
      .subscribe(params => this.return = params['return'] || '/');
  }

  login(credentials: any) {
    this.auth.login(credentials);
    this.router.navigateByUrl(this.return.toString());
  }
}
