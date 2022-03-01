import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpConfigInterceptor } from 'ness-framework-client';
import { ModalDialogService, ModalDialogModule, UtilitiesService, LoaderService, LoaderModule } from 'ness-framework-client';

import { AppComponent } from './app.component';
import { Header } from "./components/shared/header.component";
import { UserListComponent } from "./components/userList.component";
import { UserUpdateComponent } from "./components/userUpdate.component";

const routes: Routes = [
  { path: "UserList", component: UserListComponent },
  { path: "UserUpdate", component: UserUpdateComponent },
  { path: 'UserUpdate/:id', component: UserUpdateComponent },
  {
    path: '',
    redirectTo: '/UserList',
    pathMatch: 'full'
  }
]

@NgModule({
  declarations: [
    AppComponent,
    Header,
    UserListComponent,
    UserUpdateComponent
  ],
  imports: [
    CommonModule, BrowserModule, RouterModule.forRoot(routes, { useHash: true }), ReactiveFormsModule, FormsModule,
    ModalDialogModule, LoaderModule, HttpClientModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true }, ModalDialogService, UtilitiesService, LoaderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
