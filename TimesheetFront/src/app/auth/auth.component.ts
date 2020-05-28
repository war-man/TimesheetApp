import {Component} from '@angular/core';
import {UserService} from "../services/user.service";
import {Router} from "@angular/router";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent {

  emailLog: string = 'admin@admin.com';
  passwordLog: string = 'admin123';
  emailReg: string = '';
  passwordReg: string = '';
  firstName: string = '';
  lastName: string = '';

  constructor(private service: UserService, private router: Router, private snackBar: MatSnackBar) {
  }

  signIn() {
    this.service.signIn({
      email: this.emailLog,
      password: this.passwordLog
    }).then(
      logged => {
        logged ? this.router.navigate(['home']) : this.showError('Incorrect credentials');
      }
    )
  }

  register() {
    this.service.register({
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.emailReg,
      password: this.passwordReg
    }).then(
      created => {
        created ? this.router.navigate(['home']) : this.showError('Error, try other credentials');
      }
    )
  }

  showError(message) {
    this.snackBar.open(message, 'Close', {
      duration: 3000
    });
  }

}
