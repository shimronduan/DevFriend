import { Component, OnInit, Input } from '@angular/core';
import { Tutorial } from 'src/app/_models/tutorial';

@Component({
  selector: 'app-tutorial-card',
  templateUrl: './tutorial-card.component.html',
  styleUrls: ['./tutorial-card.component.css']
})
export class TutorialCardComponent implements OnInit {

  @Input() tutorial: Tutorial;

  constructor() { }
  ngOnInit() {
  }
  viewtutorial(){
    window.open(this.tutorial.tutorialUrl, '_blank');
  }
}
