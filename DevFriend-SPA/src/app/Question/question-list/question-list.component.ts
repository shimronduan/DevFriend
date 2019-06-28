import { Component, OnInit } from '@angular/core';
import { QuestionService } from 'src/app/_services/question.service';
import { Question } from 'src/app/_models/question';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { QuestionForList } from 'src/app/_models/question-for-list';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  questionList:QuestionForList[];
  constructor(private questionService:QuestionService,private alertify:AlertifyService) { }

  ngOnInit() {
  this.questionService.GetQuestions().subscribe(response => { this.questionList = response;}
    , error => { this.alertify.error("Error occured while retriving Questions !!!") });
    // this.questionService.GetQuestions().subscribe((data: QuestionForList[]) => {
    //   console.log(data);
    //   this.questionList = data;
    //   console.log(this.questionList);
    // })
  }

}
