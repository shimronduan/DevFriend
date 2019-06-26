import { Component, OnInit } from '@angular/core';
import { QuestionService } from 'src/app/_services/question.service';
import { Question } from 'src/app/_models/question';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  questionList:Question[];
  constructor(private questionService:QuestionService,private alertify:AlertifyService) { }

  ngOnInit() {
   this.questionService.GetQuestions().subscribe(response => { this.questionList = response;}
    , error => { this.alertify.error("Error occured while retriving Questions !!!") });
    debugger;
    console.log(this.questionList)
  }

}
