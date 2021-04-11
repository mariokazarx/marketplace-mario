import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { LoginService } from 'src/app/authentication/login.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {

  constructor(
    private router: Router,
    private loginService: LoginService
  ) {}

  canActivate() {
    const isLoggedIn = this.loginService.isLoggedIn();

    if (!isLoggedIn) {
      this.router.navigate(['login']);
    }

    return isLoggedIn;
  }

}
