import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Question } from "../_models/question";
import { QuestionForList } from "../_models/question-for-list";
import { QuestionForDetail } from "../_models/question-for-detail";
import { AnswerForPost } from "../_models/answer-for-post";
import { AnswerForList } from "../_models/answer-for-list";

@Injectable({
  providedIn: "root"
})
export class QuestionService {
  baseUrl = environment.apiUrl + "question/";

  constructor(private http: HttpClient) {}

  PostQuestion(question: Question) {
    return this.http.post(this.baseUrl, question);
  }
  PostAnswer(userid: string, answer: AnswerForPost) {
    return this.http.post(
      this.baseUrl + "questions/" + userid + "/postanswer",
      answer
    );
  }
  GetQuestions() {
    return this.http.get<QuestionForList[]>(this.baseUrl + "questions");
  }
  GetQuestion(id) {
    return this.http.get<QuestionForDetail>(this.baseUrl + "questions/" + id);
  }
  GetAnswersByQuestionId(id) {
    return this.http.get<AnswerForList[]>(
      this.baseUrl + "questions/" + id + "/answer"
    );
  }
}
