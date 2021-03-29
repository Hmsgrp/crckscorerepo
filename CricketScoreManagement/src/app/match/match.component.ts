import { Component, OnInit ,ViewChild } from '@angular/core';
import{NgForm, FormControl, FormGroup} from '@angular/forms';
import { Match } from '../Models/match';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.css']
})
export class MatchComponent implements OnInit {

  @ViewChild('RegisterTeam', {static: false}) RegisterTeam: NgForm;
  @ViewChild('closebutton') closebutton;
  showSuccess:boolean;
  Matches : Match[] = [];
  MatchID:number;
  modelTitletext :string;
  modelButtontext:string;
  isEdit:boolean;
  isadmin:boolean

  constructor(private US: UserService) { }

  ngOnInit(): void {
    this.isadmin=false;
    this.getrole();
    this.getMatches();
    this.initVariables(); 
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

  initVariables()
  {
    this.showSuccess=false;
    this.modelTitletext = "Add Team";
    this.modelButtontext = "Save";
  }

  submitMatch()
  {
  if(this.isEdit)
  {
    this.UpdateMatch();
  }else
  {
    this.AddMatch();
  }
  }

  AddMatch()
  {
    this.US.AddMatch(this.RegisterTeam.form)
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


  UpdateMatch()
  {
    this.US.UpdateMatch(this.RegisterTeam.form,this.MatchID)
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

  delete(id:number)
  {
    this.US.deleteMatch(id)
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

  getMatches()
  {
    this.US.getMatches()
    .subscribe(data => { 
      console.log(data);
       this.Matches = data;
    },
    error => {
      console.log(error);
    }  
    );
  }

  Edit(id:number)
  {
    let match = this.Matches.find(t=>t.matchID == id)
    this.RegisterTeam.form.controls.MatchName.setValue(match.matchName);
    this.modelTitletext = "Update Match";
    this.modelButtontext = "Update";
    this.MatchID = id;
    this.isEdit = true;
  }

  Add()
  {
    this.RegisterTeam.form.reset();
    this.isEdit = false;
    this.modelTitletext = "Add Match";
    this.modelButtontext = "Save";
  }


  handleSuccess()
  {
    this.getMatches();
    this.closebutton.nativeElement.click();
    this.RegisterTeam.form.reset();
    setTimeout(() => {
      this.showSuccess=false;
    }, 1000);
  }


}
