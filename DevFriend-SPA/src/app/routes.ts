import { Routes } from '@angular/router';
import { JobsComponent } from './jobs/jobs.component';
import { StudyComponent } from './study/study.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { RegisterComponent } from './register/register.component';
import { QuestionDetailComponent } from './Question/question-detail/question-detail.component';
import { QuestionDetailResolver } from './_resolvers/question-detail.resolver';
import { UserComponent } from './user/user.component';
import { UserDetailResolver } from './_resolvers/user-detail.resolver';
import { TutorialListComponent } from './tutorial/tutorial-list/tutorial-list.component';
import { TutorialListResolver } from './_resolvers/tutorial-list.resolver';


export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    // { path: 'user', component: UserComponent },
    { path: 'jobs', component: JobsComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'user/edit', component: UserComponent , resolve: { userDetail: UserDetailResolver }},
    { path: 'questions/:id', component: QuestionDetailComponent , resolve: { questionDetail: QuestionDetailResolver }},
    { path: 'study', component: TutorialListComponent, resolve: { tutorials: TutorialListResolver } },

    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            // { path: 'members', component: MemberListComponent, resolve: { users: MemberListResolver } },
            // { path: 'members/:id', component: MemberDetailComponent, resolve: { user: MemberDetailResolver } },
            // {
            //     path: 'member/edit', component: MemberEditComponent,
            //     resolve: { user: MemberEditResolver }, canDeactivate: [PreventUnsavedChanges]
            // },
            // { path: 'lists', component: ListsComponent },
            // { path: 'messages', component: MessagesComponent }
        ]
    }
    // // {
    // //     path: '',
    // //     runGuardsAndResolvers: 'always',
    // //     canActivate: [AuthGuard],
    // //     children: [
    // //         { path: 'members', component: MemberListComponent, resolve: { users: MemberListResolver } },
    // //         { path: 'members/:id', component: MemberDetailComponent, resolve: { user: MemberDetailResolver } },
    // //         {
    // //             path: 'member/edit', component: MemberEditComponent,
    // //             resolve: { user: MemberEditResolver }, canDeactivate: [PreventUnsavedChanges]
    // //         },
    // //         { path: 'lists', component: ListsComponent },
    // //         { path: 'messages', component: MessagesComponent }
    // //     ]
    // // },

    // { path: '**', redirectTo: '', pathMatch: 'full' }
];