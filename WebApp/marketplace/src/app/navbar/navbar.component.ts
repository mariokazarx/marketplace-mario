import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../authentication/login.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor( public readonly logingService: LoginService,
    private router: Router) { }

  navbarOpen: boolean = false;

  ngOnInit(): void {
  }

  logout(){
    this.logingService.logout();
    this.router.navigate(['/login']);
    this.navbarOpen = false;
  }
}
