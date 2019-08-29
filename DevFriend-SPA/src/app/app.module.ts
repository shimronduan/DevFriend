import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {
  BsDropdownModule,
  TabsModule,
  BsDatepickerModule,
  ModalModule
} from "ngx-bootstrap";
import { JwtModule } from "@auth0/angular-jwt";
import { RouterModule } from "@angular/router";
import { NgMultiSelectDropDownModule } from "ng-multiselect-dropdown";
import { AngularFireModule } from "@angular/fire";
import { AngularFirestoreModule } from "@angular/fire/firestore";
import { AngularFireStorageModule } from "@angular/fire/storage";
import { environment } from "src/environments/environment";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ValueComponent } from "./value/value.component";
import { HttpClientModule } from "@angular/common/http";
import { NavComponent } from "./nav/nav.component";
import { AuthService } from "./_services/auth.service";
import { AlertifyService } from "./_services/alertify.service";
import { JobsComponent } from "./jobs/jobs.component";
import { appRoutes } from "./routes";
import { StudyComponent } from "./study/study.component";
import { HomeComponent } from "./home/home.component";
import { RegisterComponent } from "./register/register.component";
import { PostQuestionComponent } from "./Question/post-question/post-question.component";
import { TagService } from "./_services/tag.service";
import { QuestionListComponent } from "./Question/question-list/question-list.component";
import { QuestionDetailComponent } from "./Question/question-detail/question-detail.component";
import { QuestionDetailResolver } from "./_resolvers/question-detail.resolver";
import { PostAnswerComponent } from "./Question/post-answer/post-answer.component";
import { TutorialCardComponent } from "./tutorial/tutorial-card/tutorial-card.component";
import { TutorialListComponent } from "./tutorial/tutorial-list/tutorial-list.component";
import { UserComponent } from "./user/user.component";
import { UserDetailResolver } from "./_resolvers/user-detail.resolver";
import { UploaderComponent } from "./uploader/uploader/uploader.component";
import { UploadTaskComponent } from "./uploader/upload-task/upload-task.component";
import { UploadTutorialsComponent } from "./upload-tutorials/upload-tutorials.component";
import { TutorialService } from './_services/tutorial.service';
import { TutorialListResolver } from './_resolvers/tutorial-list.resolver';

export function tokenGetter() {
  return localStorage.getItem("token");
}
export function firebaseConfigGetter() {
  return environment.firebaseConfig;
}

@NgModule({
  declarations: [
    AppComponent,
    ValueComponent,
    NavComponent,
    JobsComponent,
    StudyComponent,
    HomeComponent,
    RegisterComponent,
    PostQuestionComponent,
    QuestionListComponent,
    QuestionDetailComponent,
    PostAnswerComponent,
    TutorialCardComponent,
    TutorialListComponent,
    UserComponent,
    UploaderComponent,
    UploadTaskComponent,
    UploadTutorialsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    NgMultiSelectDropDownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:44342"],
        blacklistedRoutes: ["localhost:44342/api/auth"]
      }
    }),
    TabsModule.forRoot(),
    BsDatepickerModule.forRoot(),
    AngularFireModule.initializeApp(firebaseConfigGetter()),
    AngularFirestoreModule,
    AngularFireStorageModule
  ],
  providers: [
    AuthService,
    AlertifyService,
    TagService,
    TutorialService,
    QuestionDetailResolver,
    UserDetailResolver,
    TutorialListResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
