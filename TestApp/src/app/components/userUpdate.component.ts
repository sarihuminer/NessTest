
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { role } from '../models/role.model';
import { user } from '../models/user.model';
import { RoleService } from '../services/role.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'user-update',
  templateUrl: 'userUpdate.html'
})
export class UserUpdateComponent implements OnInit {
  Userid: string;
  user: user = new user();
  roleList: role[] = [];

  constructor(private route: ActivatedRoute, private userService: UserService, private roleService: RoleService) {
    this.user.isActive = false;
    this.getAll();
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
      } else {
        this.user.roleCode = 0;
      }

      console.log(id);
    });
  }
  addUser() {
    this.userService.AddUser(this.user).subscribe(res => {
      console.log(res);
    }, err => { console.log(err); })


  }

  getAll() {
    this.roleService.getRoles().subscribe(res => {
      console.log(res);
      this.roleList = res;
    }, err => {
      console.log(err);
    })
  }
}