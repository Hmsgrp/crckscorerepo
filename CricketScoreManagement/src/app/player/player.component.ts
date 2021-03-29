import { Component, OnInit ,ViewChild } from '@angular/core';
import{NgForm, FormControl, FormGroup} from '@angular/forms';
import { Team } from '../Models/Team';
import { Player } from '../Models/player';
import { UserService } from '../Services/user.service';
import {NgSelectModule, NgOption} from '@ng-select/ng-select';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  @ViewChild('closebutton') closebutton;s
  @ViewChild('Register', {static: false}) Register: NgForm;
  showSuccess:boolean;
  modelTitletext :string;
  modelButtontext:string;
  isEdit:boolean;
  selected:number;
  Teams : Team[] = [];
  Player : any;
  errorSelected :boolean;
  playerid:number
  isadmin:boolean;
  searchText;

  constructor(private US: UserService) { }

  ngOnInit(): void {
    this.isadmin = false;
    this.isEdit = false;
    this.getrole()
    this.getTeams();
    this.getPlayers();
  }

  getrole()
  {
    console.log(1);
    var f = localStorage.getItem("Role");
    if(f == "1")
    {
      this.isadmin = true;
    }
    else{
      this.isadmin = false;
    }
  }

  Add()
  {
    this.isEdit = false;
    this.modelTitletext = "Add Player";
  }

  submit()
  {
    if(!this.selected)
    {
      this.errorSelected = true;
      return false;
    }

    if(this.isEdit)
    {
      this.UpdatePlayer();
    }
    else{
      this.AddPlayer();
    }
    
  }

  getTeams()
  {
    this.US.getTeams()
    .subscribe(data => { 
       this.Teams = data;
    },
    error => {
      console.log(error);
    }  
    );
  }

  AddPlayer()
  {
    this.US.AddPlayer(this.Register.form,this.selected)
    .subscribe(data => {
       this.handleSuccess();
       this.showSuccess = true;
    },
    error => {
      console.log(error);
    }  
    );
  }

  UpdatePlayer()
  {
    this.US.Updateplayer(this.Register.form, this.playerid, this.selected)
    .subscribe(data => {
       console.log(this.selected);
       this.handleSuccess();
       this.showSuccess=true;
    },
    error => {
      console.log(error);
    }  
    );
  }

  Edit(playerID:number)
  {
    
    this.playerid=playerID;
    this.isEdit = true;
    this.modelTitletext = "Update Player";
    let player = this.Player.find(t=>t.playerID == playerID);
    this.selected = player.teamID
    this.Register.form.controls.PlayerName.setValue(player.playerName);
  }

  delete(playerID:number)
  {
    this.US.deleteplayer(playerID)
    .subscribe(data => {
       console.log(data);
       this.handleSuccess();
       this.showSuccess=true;
    },
    error => {
      console.log(error);
    });
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

  handleSuccess()
  {
    this.getPlayers();
    this.closebutton.nativeElement.click();
    this.Register.form.reset();
    setTimeout(() => {
      this.showSuccess=false;
    }, 1000);
  }
}
