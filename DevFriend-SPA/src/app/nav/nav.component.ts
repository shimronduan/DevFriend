import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  photoUrl:string;
  constructor(public authService: AuthService, private alertify: AlertifyService, private router:Router) { }

  ngOnInit() {
    this.authService.currentPhotourl.subscribe(photoUrl=>this.photoUrl=photoUrl)
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('logged in successfully')
    }, error => {
      this.alertify.error("incorrect username or password")
    },()=>{
      this.router.navigate(['/home']);
    })
  }

  loggedIn() {
    // const token = localStorage.getItem('token');
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authService.decodedToken=null;
    this.authService.currentUser=null;
    this.router.navigate(['/home']);
    this.alertify.message('logged out');
  }
}
