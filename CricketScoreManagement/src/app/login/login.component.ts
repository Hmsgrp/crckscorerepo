
import { Component, OnInit,ViewChild } from '@angular/core';
import{NgForm, FormControl} from '@angular/forms';
import{UserService} from '../Services/user.service'
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers:[UserService]
})

export class LoginComponent implements OnInit {
  constructor(public userService:UserService,private router: Router) { }
  @ViewChild('Register', {static: false}) Register: NgForm;
  showSuccessLogin:boolean;
  showFailureLogin:boolean;
  errors:boolean;
  errortext:string;
  ngOnInit(): void {
    this.showSuccessLogin = false;
    this.showFailureLogin=false;
    this.errors = false;
  }

  submit(){

    this.userService.Login(this.Register.form)
    .subscribe(data => {
      console.log(data);
      const helper = new JwtHelperService();
      const decodedToken = helper.decodeToken((<any> data).token);
      localStorage.setItem("access_token",(<any> data).token);
      localStorage.setItem("Role",decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
     // this.router.navigate(["/CricScore"]);
      var gotoURL= window.location.origin + "/CricScore" ;
       window.location.href = gotoURL;
    },
    HttpErrorResponse => {
     this.errortext = HttpErrorResponse.error;
     this.errors = true;
    }  
    );
  }
}

