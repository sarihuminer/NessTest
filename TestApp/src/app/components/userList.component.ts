
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { user } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'user-list',
  templateUrl: 'userList.html'
})
export class UserListComponent {

  usersList: user[] = [];
  constructor(private userService: UserService) {
    this.getAll();
  }

  getAll() {
    this.userService.getList().subscribe(res => {
      console.log(res);
      this.usersList = res;
    }, err => {
      console.log(err);
    })
  }

}
