import { Component, OnInit } from '@angular/core';
import { Tutorial } from '../_models/tutorial';
import { Tag } from '../_models/tag';
import { TagService } from '../_services/tag.service';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { TutorialService } from '../_services/tutorial.service';

@Component({
  selector: 'app-upload-tutorials',
  templateUrl: './upload-tutorials.component.html',
  styleUrls: ['./upload-tutorials.component.css']
})
export class UploadTutorialsComponent implements OnInit {

  tags:Tag[];
  dropdownSettings: any = {};
  tutorial:Tutorial;
  userid:string;
  constructor(private tutorialService:TutorialService
    ,private alertify:AlertifyService,private authService:AuthService,private tagService:TagService) {
      this.tutorial=new Tutorial();
   }

  ngOnInit() {
    this.tagService.getTags()
    .subscribe(response => { this.tags = response;
    debugger;
    }
      , error => { this.alertify.error("Error occured while retriving tags data !!!") });


      this.dropdownSettings = {
        singleSelection: false,
        idField: 'id',
        textField: 'name',
        enableCheckAll:false,
        allowSearchFilter: true
    };
    this.userid=this.authService.decodedToken.nameid;
  }
  getTutorialUrl(url){
    this.tutorial.tutorialUrl=url
  }
  getIconUrl(url){
    this.tutorial.iconUrl=url
  }
  SaveUpload(){
    if(this.userid==undefined){
      this.alertify.error("Please login first")
    }else{
      this.tutorial.UserId = this.authService.decodedToken.nameid;
      this.tutorialService.Upload(this.tutorial).subscribe(next => {
      
        this.alertify.success('Uploaded successfully');
      }, error => {
        this.alertify.error("error")
      },()=>{
        // this.router.navigate(['/members']);
      })
    }

  }
}
