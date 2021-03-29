import { Component, OnInit ,ViewChild } from '@angular/core';
import{ NgForm, FormControl, FormGroup } from '@angular/forms';
import { Match } from '../Models/match';
import { Team } from '../Models/Team';
import { Score } from '../Models/score';
import { UserService } from '../Services/user.service';
import {NgSelectModule, NgOption} from '@ng-select/ng-select';

@Component({
  selector: 'app-player-score',
  templateUrl: './player-score.component.html',
  styleUrls: ['./player-score.component.css']
})
export class PlayerScoreComponent implements OnInit {

  @ViewChild('RegisterTeam', {static: false}) RegisterTeam: NgForm;
  @ViewChild('closebutton') closebutton;
  showSuccess:boolean;
  Matches : Match[] = [];
  Scores : Score[] = [];
  ScoreID:number;
  modelTitletext :string;
  modelButtontext:string;
  isEdit:boolean;
  selectedPlayer:number;
  selectedMatch:number;
  selectedItemsPlayer=[];
  Player : any;
  showp:boolean;
  isadmin:boolean;
  searchText;

  constructor(private US: UserService) { }

  ngOnInit(): void {
    this.isadmin = false
    this. getrole()
    this.getScores();
    this.getPlayers();
    this.getMatches();
    this.initVariables(); 
  }


  getrole()
  {
    var f = localStorage.getItem("Role");
    if(f == "1")
    {
      this.isadmin = true;
    }
    else{
      this.isadmin = false;
    }
  }

  initVariables()
  {
    //this.selectedPlayer=[];
    //this.selectedMatch=[];
    this.showp = false;
    this.showSuccess=false;
    this.modelTitletext = "Add Team";
    this.modelButtontext = "Save";
  }

  submitScore()
  {
    if(this.isEdit)
    {
      this.UpdateScore();
    }else
    {
      this.AddScore();
    }
  }

  AddScore()
  {
    this.US.AddScore(this.RegisterTeam.form,this.selectedPlayer,this.selectedMatch)
    .subscribe(data => {
       console.log(data);
       this.handleSuccess();
       this.showSuccess=true;
    },
    error => {
      console.log(error);
    }  
    );
  }


  UpdateScore()
  {
    this.US.UpdateScore(this.RegisterTeam.form,this.ScoreID,this.selectedPlayer,this.selectedMatch)
    .subscribe(data => {
       this.handleSuccess();
       this.showSuccess=true;
    },
    error => {
      console.log(error);
    }  
    );
  }

  delete(id:number)
  {
    this.US.deleteScore(id)
    .subscribe(data => {
       this.handleSuccess();
       this.showSuccess=true;
    },
    error => {
      console.log(error);
    }  
    );
  }

  getScores()
  {
    this.US.getScore()
    .subscribe(data => {
      console.log(data);
       this.Scores = data;
    },
    error => {
      console.log(error);
    }  
    );
  }

  getMatches()
  {
    this.US.getMatches()
    .subscribe(data => { 
       this.Matches = data;
    },
    error => {
      console.log(error);
    }  
    );
  }

  getPlayers()
  {
    this.US.getPlayers()
    .subscribe(data => { 
      this.Player = data;
    },
    error => {
      console.log(error);
    }  
    );
  }
  

  Edit(id:number)
  {
    this.showp = true;
    let match = this.Scores.find(t=>t.scoreID == id)
    this.ScoreID=match.scoreID;
    this.selectedPlayer = match.playerID;
    this.selectedMatch = match.matchID;
    this.RegisterTeam.form.controls.Score.setValue(match.score);
    this.RegisterTeam.form.controls.balls.setValue(match.balls);
    this.modelTitletext = "Update Score";
    this.modelButtontext = "Update";
    this.isEdit = true;
  }

  Add()
  {
    this.showp = false;
    this.RegisterTeam.form.reset();
    this.isEdit = false;
    this.modelTitletext = "Add Score";
    this.modelButtontext = "Save";
  }


  handleSuccess()
  {
    this.getScores()
    this.closebutton.nativeElement.click();
    this.RegisterTeam.form.reset();
    setTimeout(() => {
      this.showSuccess=false;
    }, 1000);
  }
}
