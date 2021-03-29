import { Component, OnInit } from '@angular/core';
import { UserService } from '../Services/user.service';
import { summaryInfo } from '../Models/summaryInfo';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  summaryinf : summaryInfo[] = [];
  summary:any;
  searchText;

  constructor(private US: UserService) { }

  ngOnInit(): void {
    this.getSummaryInfo();
    this.getSummary()
  }


  getSummaryInfo()
  {
    this.US.getSummaryInfo()
    .subscribe(data => { 
      console.log(data);
       this.summaryinf = data;
    },
    error => {
      console.log(error);
    }  
    );
  }

  getSummary()
  {
    this.US.getSummary()
    .subscribe(data => { 
      console.log(data);
       this.summary = data;
    },
    error => {
      console.log(error);
    }  
    );
  }





}
