import {Component} from '@angular/core';
import {TimesheetsService} from "../services/timesheets.service";
import {ReportedTime} from "../models/reported-time.model";

@Component({
  selector: 'app-timesheets',
  templateUrl: './timesheets.component.html',
  styleUrls: ['./timesheets.component.scss']
})
export class TimesheetsComponent {

  times: ReportedTime[] = [];

  constructor(private service: TimesheetsService) {
    this.service.getTimesheets().then(data => {
      this.times = data.sort((a, b) => parseInt(b.date) - parseInt(a.date));
    });
  }

  delete(id: number) {
    this.service.deleteTimesheet(id).then(response => {
      if (response.statusCode === 200) {
        this.times = this.times.filter(t => t.id !== id);
      }
    });
  }

}
