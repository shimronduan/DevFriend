import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';
import { User } from '../_models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private route: ActivatedRoute, private alertify: AlertifyService,private userService:UserService,private authService:AuthService) { }
  user: User;
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data['userDetail'];
    });
    console.log("username: "+this.user.username);
    // this.authService.currentPhotourl.subscribe(photoUrl=>this.photoUrl=photoUrl);
  }
   imgurl:string ='https://ununsplash.imgix.net/photo-1431578500526-4d9613015464?fit=crop&fm=jpg&h=300&q=75&w=400';
  


}
