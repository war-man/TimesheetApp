import {Component} from '@angular/core';
import {UserService} from "../services/user.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  constructor(readonly service: UserService) {
  }

  logout = () => this.service.logout();

}
