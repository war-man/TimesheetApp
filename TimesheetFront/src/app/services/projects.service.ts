import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Project} from "../models/project.model";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  constructor(private httpClient: HttpClient) {
  }

  getProjects(): Promise<Project[]> {
    return this.httpClient.get<Project[]>(environment.backofficeUrl + '/Projects').toPromise();
  }

  addProject(project: {name: string}): Promise<{value: Project, statusCode: number}> {
    return this.httpClient.post<{value: Project, statusCode: number}>(environment.backofficeUrl + '/AddProject', project).toPromise();
  }

  activateProject(project: Project): Promise<{statusCode: number}> {
    return this.httpClient.post<{statusCode: number}>(environment.backofficeUrl + '/EnableProject', project).toPromise();
  }

  deactivateProject(project: Project): Promise<{statusCode: number}> {
    return this.httpClient.post<{statusCode: number}>(environment.backofficeUrl + '/DisableProject', project).toPromise();
  }

}
