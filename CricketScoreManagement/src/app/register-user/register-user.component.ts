import { Component, OnInit,ViewChild } from '@angular/core';
import{NgForm, FormControl} from '@angular/forms';
import{UserService} from '../Services/user.service'
import{User} from '../Models/user'
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css'],
  providers:[UserService]
})
export class RegisterUserComponent implements OnInit {
 @ViewChild('Register', {static: false}) Register: NgForm;
showSuccessMessage:boolean;
serverErrorMessage:string;
EmailError:boolean;
UserNameError: boolean;
PhoneNumberError: boolean;
Notmatch:boolean;
Users : User[] = [];
constructor(public userService:UserService,public route:Router) { }
  ngOnInit(): void {
  }

  submit(){
    if(this.Register.form.controls.Password.value != this.Register.form.controls.ConfirmPassword.value)
    {
      this.Notmatch =true;
      return false
    }

    this.userService.RegisterUser(this.Register.form)
    .subscribe(data => {
      this.route.navigate(["/Login"]);
    },
    error => {
      console.log(error);
    }  
    );

  } 
}
