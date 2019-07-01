import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BsDropdownModule, TabsModule, BsDatepickerModule, ModalModule } from 'ngx-bootstrap';
import { JwtModule } from '@auth0/angular-jwt';
import { RouterModule } from '@angular/router';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { JobsComponent } from './jobs/jobs.component';
import { appRoutes } from './routes';
import { StudyComponent } from './study/study.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { PostQuestionComponent } from './Question/post-question/post-question.component';
import { TagService } from './_services/tag.service';
import { QuestionListComponent } from './Question/question-list/question-list.component';
import { QuestionDetailComponent } from './Question/question-detail/question-detail.component';
import { QuestionDetailResolver } from './_resolvers/question-detail.resolver';

export function tokenGetter(){
   return localStorage.getItem('token');
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
      QuestionDetailComponent
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
         config:{
            tokenGetter:tokenGetter,
            whitelistedDomains: ['localhost:44342'],
            blacklistedRoutes:['localhost:44342/api/auth']
         }
      }),
      TabsModule.forRoot(),
      BsDatepickerModule.forRoot()
   ],
   providers: [
      AuthService,
      AlertifyService,
      TagService,
      QuestionDetailResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
