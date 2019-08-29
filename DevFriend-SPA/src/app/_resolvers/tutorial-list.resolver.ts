import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { Tutorial } from '../_models/tutorial';
import { TutorialService } from '../_services/tutorial.service';

@Injectable()
export class TutorialListResolver implements Resolve<Tutorial[]>{
    /**
     *
     */
    constructor(private tutorialService: TutorialService, private router: Router, private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<Tutorial[]> {
        return this.tutorialService.getTutorials().pipe(
            catchError(error => {
                this.alertify.error("Preblem retriving data");
                this.router.navigate(['/home']);
                return of(null);
            })
        )
    }

}