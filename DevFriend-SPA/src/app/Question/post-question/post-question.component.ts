import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Question } from 'src/app/_models/question';
import { TagService } from 'src/app/_services/tag.service';
import { Tag } from 'src/app/_models/tag';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { QuestionService } from 'src/app/_services/question.service';

@Component({
  selector: 'app-post-question',
  templateUrl: './post-question.component.html',
  styleUrls: ['./post-question.component.css']
})
export class PostQuestionComponent implements OnInit {

  @Output() questionOutput = new EventEmitter<Question>();
  question:Question;
  tags:Tag[];
  postQuestionTag:any;
  dropdownSettings: any = {};
  constructor(private tagService:TagService,private alertify:AlertifyService,
    private _question:Question,private questionservice:QuestionService) {
    this.question = this._question;
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
  }
  PostQuestion(){
    // this.question;
    // debugger;
    // console.log(this.postQuestionTag);
    this.questionservice.PostQuestion(this.question).subscribe(next => {
      this.questionOutput.emit(this.question);
      this.alertify.success('Query posted successfully')
    }, error => {
      this.alertify.error(error)
    },()=>{
      // this.router.navigate(['/members']);
    })
  }

}
