import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TeamComponent } from './team/team.component';
import { MatchComponent } from './match/match.component';
import { PlayerComponent } from './player/player.component';
import { ScoreComponent } from './score/score.component';
import { PlayerScoreComponent } from './player-score/player-score.component';
import { FormsModule }   from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { JwtModule } from "@auth0/angular-jwt";
import { NgSelectModule } from '@ng-select/ng-select';
import { AddRequestHeaderService } from './add-request-header.service';
import { HttpClientModule ,HTTP_INTERCEPTORS } from '@angular/common/http';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

export function tokenGetter() {
  return localStorage.getItem("access_token");
}

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    TeamComponent,
    MatchComponent,
    PlayerComponent,
    ScoreComponent,
    PlayerScoreComponent,
    LoginComponent,
    RegisterUserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgSelectModule,
    Ng2SearchPipeModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44367","localhost:4200"],
        disallowedRoutes: [""],
      },
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AddRequestHeaderService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
