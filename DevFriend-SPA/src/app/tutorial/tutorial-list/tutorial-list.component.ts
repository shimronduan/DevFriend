import { Component, OnInit } from '@angular/core';
import { Tutorial } from 'src/app/_models/tutorial';
import { TutorialService } from 'src/app/_services/tutorial.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tutorial-list',
  templateUrl: './tutorial-list.component.html',
  styleUrls: ['./tutorial-list.component.css']
})
export class TutorialListComponent implements OnInit {

  tutorials: Tutorial[];
  constructor(private userService: TutorialService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.tutorials = data['tutorials'];
    });
  }
}
