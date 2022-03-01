
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { user } from '../models/user.model';
import { UserService } from '../services/user.service';
import { Router } from "@angular/router"

@Component({
  selector: 'user-list',
  templateUrl: 'userList.html'
})
export class UserListComponent {

  usersList: user[] = [];

  userName: string;
  userRole: number;

  constructor(private userService: UserService, private router: Router) {
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
  search() {
    this.userService.search(this.userRole, this.userName).subscribe(res => {
      console.log(res);
      this.usersList = res;
    }, err => {
      console.log(err);
    })
  }
  update(userId: number) {
    this.router.navigate(["/UserUpdate", userId]);
  }
}
