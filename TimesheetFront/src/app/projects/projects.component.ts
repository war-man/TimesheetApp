import {Component} from '@angular/core';
import {ProjectsService} from "../services/projects.service";
import {Project} from "../models/project.model";

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent {

  newName: string = '';
  projects: Project[] = [];

  constructor(private service: ProjectsService) {
    this.service.getProjects().then(data => {
      this.projects = data;
    });
  }

  add() {
    this.service.addProject({name: this.newName}).then(project => {
      this.newName = '';
      this.projects = [project.value, ...this.projects];
    });
  }

  activate(project: Project) {
    this.service.activateProject(project).then(response => {
      if (response.statusCode === 200) {
        this.projects = this.projects.map(p => p.id === project.id ? {
          ...project,
          isValid: true
        } : p);
      }
    });
  }

  deactivate(project: Project) {
    this.service.deactivateProject(project).then(response => {
      if (response.statusCode === 200) {
        this.projects = this.projects.map(p => p.id === project.id ? {
          ...project,
          isValid: false
        } : p);
      }
    });
  }

}
