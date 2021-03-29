import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import{HttpClient} from '@angular/common/http';
import{environment} from 'src/environments/environment';
import { Team } from '../Models/Team';
import { Player } from '../Models/player';
import{NgForm, FormControl, FormGroup} from '@angular/forms';
import { Observable } from 'rxjs';
import { User } from '../Models/user';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Match } from '../Models/match';
import { Score } from '../Models/score';
import { summaryInfo } from '../Models/summaryInfo';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient,private router: Router) { }

//Teams Section -start
  AddTeam(FormGroupValues:FormGroup) : Observable<any>
  {
    const team = new Team();
    team.teamName =  FormGroupValues.controls.TeamName.value;
    team.createdDate = new Date();
    team.status = true;

    const headers = { 'content-type': 'application/json'}  
    let endPoints = "Team/AddTeam"
    const body=JSON.stringify(team);
    console.log(body)
    return this.http.post(environment.apiUrl + endPoints, body,{'headers':headers})
  }

  Updateteam(FormGroupValues:FormGroup,teamid:number): Observable<any>{

    const team = new Team();
    team.teamID = teamid;
    team.teamName =  FormGroupValues.controls.TeamName.value;
    team.updatedDate = new Date();

    const headers = { 'content-type': 'application/json'}  
    const roledata=JSON.stringify(team);
    let endPoints = "Team/UpdateTeam"
    return this.http.put(environment.apiUrl + endPoints, roledata,{'headers':headers});
  }

  deleteTeam(id:number) : Observable<any>{
    let endPoints = "Team/DeleteTeam/"
    return this.http.delete(environment.apiUrl + endPoints + id);
  }

  getTeams(): Observable<Team[]> {
    let endPoints = "Team/GetTeams"
    return this.http.get<Team[]>(environment.apiUrl + endPoints)
  }
//Teams Section -End

//player Section -start
AddPlayer(FormGroupValues:FormGroup,teamid:number) : Observable<any>
{
  const player = new Player();
  player.PlayerName =  FormGroupValues.controls.PlayerName.value;
  player.TeamID = teamid;
  player.CreatedDate = new Date();
  player.Status = true;

  const headers = { 'content-type': 'application/json'}  
  let endPoints = "Play/AddPlayerV1"
  const body = JSON.stringify(player);
  return this.http.post(environment.apiUrl + endPoints, body,{'headers':headers})
}

Updateplayer(FormGroupValues:FormGroup,playerID:number,teamid:number): Observable<any>{

  const play = new Player();
  play.PlayerID = playerID;
  play.PlayerName =  FormGroupValues.controls.PlayerName.value;
  play.TeamID =teamid;
  play.UpdatedDate = new Date();

  const headers = { 'content-type': 'application/json'}  
  const body = JSON.stringify(play);
  let endPoints = "Play/UpdatePlayerV1"
  return this.http.put(environment.apiUrl + endPoints, body,{'headers':headers});
}

deleteplayer(id:number) : Observable<any>{
  let endPoints = "Play/DeletePlayerV1/"
  return this.http.delete(environment.apiUrl + endPoints + id);
}

getPlayers(): Observable<any> {
  let endPoints = "Play/GetPlayerV1"
  return this.http.get<any>(environment.apiUrl + endPoints)
}
//player Section end

//Match Section -start
AddMatch(FormGroupValues:FormGroup) : Observable<any>
{
  const match = new Match();
  match.matchName =  FormGroupValues.controls.MatchName.value;
  match.createdDate = new Date();
  match.status = true;

  const headers = { 'content-type': 'application/json'}  
  let endPoints = "Match/AddMatch"
  const body=JSON.stringify(match);
  console.log(body)
  return this.http.post(environment.apiUrl + endPoints, body,{'headers':headers})
}

UpdateMatch(FormGroupValues:FormGroup,matchid:any): Observable<any>{

  const matc = new Match();
  matc.matchID = matchid;
  matc.matchName =  FormGroupValues.controls.MatchName.value;
  matc.updatedDate = new Date();

  const headers = { 'content-type': 'application/json'}  
  const roledata=JSON.stringify(matc);
  let endPoints = "Match/UpdateMatch"
  return this.http.put(environment.apiUrl + endPoints, roledata,{'headers':headers});
}

deleteMatch(id:number) : Observable<any>{
  let endPoints = "Match/DeleteMatch/"
  return this.http.delete(environment.apiUrl + endPoints + id);
}

getMatches(): Observable<any> {
  let endPoints = "Match/GetMatch"
  return this.http.get<any>(environment.apiUrl + endPoints)
}
//Match Section end



RegisterUser(FormGroupValues:FormGroup)
{
  const UserData = new User();
  UserData.userName =  FormGroupValues.controls.Name.value;
  UserData.password =  FormGroupValues.controls.Password.value;
  UserData.roleID =  2;
  UserData.createdDate = new Date();
  UserData.status = true;

  const headers = { 'content-type': 'application/json'}  
  let endPoints = "User/AddUser"
  const body=JSON.stringify(UserData);
  return this.http.post(environment.apiUrl + endPoints, body,{'headers':headers})
}

Login(FormGroupValues:FormGroup)
{
  const UserData = new User();
  UserData.userName =  FormGroupValues.controls.UserName.value;
  UserData.password =  FormGroupValues.controls.Password.value;

  const headers = { 'content-type': 'application/json'}  
  let endPoints = "User/Auth/Login"
  const body=JSON.stringify(UserData);
  return this.http.post(environment.apiUrl + endPoints, body,{'headers':headers})

}

getSummaryInfo(): Observable<summaryInfo[]> {
  let endPoints = "User/GetSumaryInfo"
  return this.http.get<summaryInfo[]>(environment.apiUrl + endPoints)
}

getSummary(): Observable<any[]> {
  let endPoints = "User/GetSumary"
  return this.http.get<any[]>(environment.apiUrl + endPoints)
}

//

//Score Section -start
AddScore(FormGroupValues:FormGroup,selectedPlayer:any,selectedMatch:any) : Observable<any>
{
  const score = new Score();
  score.playerID = selectedPlayer;
  score.matchID =  selectedMatch;
  score.balls =  FormGroupValues.controls.balls.value;
  score.score = FormGroupValues.controls.Score.value;

  const headers = { 'content-type': 'application/json'}  
  let endPoints = "Score/AddScore"
  const body=JSON.stringify(score);
  return this.http.post(environment.apiUrl + endPoints, body,{'headers':headers})
}

UpdateScore(FormGroupValues:FormGroup,scoreid:number,selectedPlayer:number,selectedMatch:number): Observable<any>{

  const sco = new Score();
  sco.iD = scoreid;
  sco.matchID  = selectedMatch;
  sco.playerID  = selectedPlayer;
  sco.balls =  FormGroupValues.controls.balls.value;
  sco.score = FormGroupValues.controls.Score.value;

  const headers = { 'content-type': 'application/json'}  
  const roledata=JSON.stringify(sco);
  let endPoints = "Score/UpdateScore"
  return this.http.put(environment.apiUrl + endPoints, roledata,{'headers':headers});
}


getScore(): Observable<Score[]> {
  let endPoints = "Score/GetScores"
  return this.http.get<Score[]>(environment.apiUrl + endPoints)
}

deleteScore(id:number) : Observable<any>{
  let endPoints = "Score/DeleteScore/"
  return this.http.delete(environment.apiUrl + endPoints + id);
}


 
  logout(){
    localStorage.removeItem("access_token");
    localStorage.removeItem("Role");
    this.router.navigate(["/Login"]);
   }


}
