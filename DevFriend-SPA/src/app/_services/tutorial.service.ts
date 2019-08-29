import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import{BehaviorSubject, Observable}from 'rxjs';
import { Tag } from '../_models/tag';
import { Tutorial } from '../_models/tutorial';
@Injectable({
  providedIn: 'root'
})
export class TutorialService {
  baseUrl = environment.apiUrl + 'Tutorial/';

  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser:User;

  constructor(private http: HttpClient) { }

  Upload(model: Tutorial) {
    debugger;
    return this.http.post(this.baseUrl + 'upload', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          
        }
      })
    )
  }
  getTutorials(): Observable<Tutorial[]> {
    return this.http.get<Tutorial[]>(this.baseUrl);
  }
}
