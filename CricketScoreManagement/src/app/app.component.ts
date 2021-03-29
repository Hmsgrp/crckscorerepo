import { Component ,OnInit} from '@angular/core';
import{UserService} from '../app/Services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'CricketScoreCardManagement';
  showMenu:boolean;

  constructor(public userService:UserService){}

  ngOnInit(): void {
    this.showMenu=false;
    this.getToken();
  }

  getToken()
  {
    var token = localStorage.getItem("access_token");
    if(token)
    {
      this.showMenu=true;
    }
  }

  logoutUser()
  {
    this.userService.logout();
  }
  
  
}
