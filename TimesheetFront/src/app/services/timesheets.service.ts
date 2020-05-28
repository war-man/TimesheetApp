import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ReportedTime} from "../models/reported-time.model";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class TimesheetsService {

  constructor(private httpClient: HttpClient) {
  }

  getTimesheets(): Promise<ReportedTime[]> {
    return this.httpClient.get<ReportedTime[]>(environment.backofficeUrl + '/ReportedTime').toPromise();
  }

  getUserTimesheets(userId: number): Promise<ReportedTime[]> {
    return this.httpClient.get<ReportedTime[]>(environment.backofficeUrl + '/ReportedTime/' + userId).toPromise();
  }

  addTimesheet(time: ReportedTime): Promise<{ result: { statusCode: number, value: ReportedTime } }> {
    return this.httpClient.post<{ result: { statusCode: number, value: ReportedTime } }>(environment.backofficeUrl + '/AddTime', time).toPromise();
  }

  deleteTimesheet(timeId: number): Promise<{ statusCode: number }> {
    return this.httpClient.delete<{ statusCode: number }>(environment.backofficeUrl + '/DeleteTime/' + timeId).toPromise();
  }

}
