import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/core/marketplace-api/models/user.model';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  username: string;

  constructor(
    private readonly loginService: LoginService,
    private router: Router
  ) { }


  ngOnInit(): void {
  }

  login(): void {
    this.loginService.login(this.username)
      .subscribe(
        () => {
          this.router.navigate(['']);
        },
        () => {
          alert('An error has occurred while logging user');
        });
  }


}
