import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import{BehaviorSubject, Observable}from 'rxjs';
import { Tag } from '../_models/tag';

@Injectable({
  providedIn: 'root'
})
export class TagService {
  baseUrl = environment.apiUrl + 'question/';

  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser:User;

  constructor(private http: HttpClient) { }

  getTags(): Observable<Tag[]> {
    return this.http.get<Tag[]>(this.baseUrl + 'tags');
  }
 

}
