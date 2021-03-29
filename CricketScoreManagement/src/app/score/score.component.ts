import { Component, OnInit ,ViewChild } from '@angular/core';
import{NgForm, FormControl, FormGroup} from '@angular/forms';
import { Match } from '../Models/match';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
