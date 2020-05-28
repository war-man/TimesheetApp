import {Project} from "./project.model";
import {User} from "./user.model";

export interface ReportedTime {
  id?: number;
  amount: number;
  date: string;
  user: User;
  project: Project;
}
