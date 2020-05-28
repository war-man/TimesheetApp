import {Component} from '@angular/core';
import {Project} from "../models/project.model";
import {ProjectsService} from "../services/projects.service";
import {ReportedTime} from "../models/reported-time.model";
import {TimesheetsService} from "../services/timesheets.service";
import {UserService} from "../services/user.service";
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  projects: Project[] = [];
  times: ReportedTime[] = [];
  amount: number = null;
  project: any;

  constructor(private projectsService: ProjectsService,
              private timesheetsService: TimesheetsService,
              private userService: UserService) {
    this.project = new FormControl();
    this.projectsService.getProjects().then(data => {
      this.projects = data.filter(p => p.isValid);
    });
    this.timesheetsService.getUserTimesheets(this.userService.getUser().id).then(data => {
      this.times = data.sort((a, b) => parseInt(b.date) - parseInt(a.date));
    });
  }

  delete(id: number) {
    this.timesheetsService.deleteTimesheet(id).then(response => {
      if (response.statusCode === 200) {
        this.times = this.times.filter(t => t.id !== id);
        this.projectsService.getProjects().then(data => {
          this.projects = data.filter(p => p.isValid);
        });
      }
    });
  }

  add(date: any) {
    const timesheet = {
      amount: this.amount,
      date,
      project: this.project.value,
      user: this.userService.getUser()
    };
    this.timesheetsService.addTimesheet(timesheet).then(response => {
      if (response.result.statusCode === 200) {
        this.times = [{...timesheet, id: response.result.value.id}, ...this.times];
        this.projectsService.getProjects().then(data => {
          this.projects = data.filter(p => p.isValid);
        });
        this.amount = null;
      }
    });
  }

}
