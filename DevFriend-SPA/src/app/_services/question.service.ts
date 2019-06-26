import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Question } from '../_models/question';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  baseUrl = environment.apiUrl + 'question/';

  constructor(private http: HttpClient) { }

  PostQuestion(question:Question){
    return this.http.post(this.baseUrl , question);
  }
  GetQuestions(){
    return this.http.get<Question[]>(this.baseUrl + 'questions');
  }
}
