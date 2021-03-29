import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RegisterUserComponent } from './register-user/register-user.component';
import { LoginComponent } from './login/login.component'; 
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ErrorComponent } from './error/error.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TeamComponent } from './team/team.component';
import { MatchComponent } from './match/match.component';
import { PlayerComponent } from './player/player.component';
import { ScoreComponent } from './score/score.component';
import { PlayerScoreComponent } from './player-score/player-score.component';
import { AuthguardService } from './auth/authguard.service';


const appRoutes: Routes = [
  { path: 'SignUp', component: RegisterUserComponent },
  { path: 'Login', component: LoginComponent },
  { path: 'ForgetPassword', component: ForgetPasswordComponent },
  { path: 'CricScore',canActivate:[AuthguardService], component: DashboardComponent },
  { path: 'Team',canActivate:[AuthguardService], component: TeamComponent },
  { path: 'Match',canActivate:[AuthguardService], component: MatchComponent },
  { path: 'Player',canActivate:[AuthguardService], component: PlayerComponent },
  { path: 'Score', canActivate:[AuthguardService],component: ScoreComponent },
  { path: 'PlayerScore',canActivate:[AuthguardService], component: PlayerScoreComponent },
//   { path: 'DashBoard', component: TransferMoneyComponent,canActivate:[AuthGuard] },
  { path: 'Error', component: ErrorComponent },
  { path: '', redirectTo: '/CricScore', pathMatch: 'full' },//StartUp page
  { path: '**', component: PageNotFoundComponent }//incorrect url
];


@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 


}
