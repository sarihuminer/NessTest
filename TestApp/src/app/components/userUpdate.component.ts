
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { user } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'user-update',
  templateUrl: 'userUpdate.html'
})
export class UserUpdateComponent implements OnInit {
  Userid: string;
  user: user = new user();
  constructor(private route: ActivatedRoute, private userService: UserService) {

  }
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      let id = params.get('id');
      if (id != undefined) {
        this.Userid = id;
        this.userService.getUser(this.Userid).subscribe(res => {
          console.log(res);
          this.user = res;
        }, err => {
          console.log(err);
        })
      }

      console.log(id);
    });
  }
  addUser() {
    this.userService.AddUser(this.user).subscribe(res => {
      console.log(res);
    }, err => { console.log(err); })


  }
}