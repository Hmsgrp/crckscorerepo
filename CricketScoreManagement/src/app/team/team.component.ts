import { Component, OnInit ,ViewChild } from '@angular/core';
import{NgForm, FormControl, FormGroup} from '@angular/forms';
import { Team } from '../Models/Team';
import { UserService } from '../Services/user.service';


@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {

  @ViewChild('RegisterTeam', {static: false}) RegisterTeam: NgForm;
  @ViewChild('closebutton') closebutton;
  showSuccess:boolean;
  Teams : Team[] = [];
  TeamID:number;
  modelTitletext :string;
  modelButtontext:string;
  isEdit:boolean;
  role:number
  isadmin:boolean;
  
  
  constructor(private US: UserService) { }

  ngOnInit(): void {
    this.isadmin = false;
    this.getrole();
    this.getTeams();
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

  submitTeam()
  {
  if(this.isEdit)
  {
    this.UpdateTeam();
  }else
  {
    this.AddTeam();
  }
  }

  AddTeam()
  {
    this.US.AddTeam(this.RegisterTeam.form)
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


  UpdateTeam()
  {
    this.US.Updateteam(this.RegisterTeam.form,this.TeamID)
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
    this.US.deleteTeam(id)
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

  Edit(id:number)
  {
    let teams = this.Teams.find(t=>t.teamID == id)
    this.RegisterTeam.form.controls.TeamName.setValue(teams.teamName);
    this.modelTitletext = "Update Team";
    this.modelButtontext = "Update";
    this.TeamID = id;
    this.isEdit = true;
  }

  Add()
  {
    this.RegisterTeam.form.reset();
    console.log(1);
    this.isEdit = false;
    this.modelTitletext = "Add Team";
    this.modelButtontext = "Save";
  }


  handleSuccess()
  {
    this.getTeams();
    this.closebutton.nativeElement.click();
    this.RegisterTeam.form.reset();
    setTimeout(() => {
      this.showSuccess=false;
    }, 1000);
  }



}
