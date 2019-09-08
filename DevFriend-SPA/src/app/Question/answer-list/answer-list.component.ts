import { Component, OnInit, Input } from '@angular/core';
import { QuestionService } from 'src/app/_services/question.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AnswerForList } from 'src/app/_models/answer-for-list';

@Component({
  selector: 'app-answer-list',
  templateUrl: './answer-list.component.html',
  styleUrls: ['./answer-list.component.css']
})
export class AnswerListComponent implements OnInit {
  
  @Input() QuestionId: string;
  answerForList:AnswerForList[];
  constructor(private _questionService:QuestionService, private alertify:AlertifyService) {
   }

  ngOnInit() {
    this.getAnswers()
  }

  getAnswers(){
    this._questionService.GetAnswersByQuestionId(this.QuestionId).subscribe(
      response => { 
        this.answerForList = response;
        debugger;
      }
      , error => { this.alertify.error("Error occured while retriving Answers !!!") });
      debugger;
  }
}
