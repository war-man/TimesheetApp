import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "../models/user.model";
import {Router} from "@angular/router";
import {Credentials} from "../models/credentials.model";
import {environment} from "../../environments/environment";
import {NewUser} from "../models/new-user.model";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private currentUser: User = null;

  constructor(private httpClient: HttpClient, private router: Router) {
  }

  getUser = () => this.currentUser;

  signIn(credentials: Credentials): Promise<boolean> {
    return this.httpClient.post<User>(environment.backofficeUrl + '/LogIn', credentials).toPromise().then(
      data => {
        this.currentUser = data;
        return true;
      },
      error => false
    )
  }

  register(newUser: NewUser): Promise<boolean> {
    return this.httpClient.post<User>(environment.backofficeUrl + '/SignUn', newUser).toPromise().then(
      data => {
        this.currentUser = data;
        return true;
      },
      error => false
    )
  }

  logout() {
    this.currentUser = null;
    this.router.navigate(['']);
  }

}
