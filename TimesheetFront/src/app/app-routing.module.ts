import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {ProjectsComponent} from "./projects/projects.component";
import {TimesheetsComponent} from "./timesheets/timesheets.component";
import {DashboardComponent} from "./dashboard/dashboard.component";
import {AuthComponent} from "./auth/auth.component";
import {AdminGuard} from "./guards/admin.guard";
import {AuthGuard} from "./guards/auth.guard";

const routes: Routes = [
  {
    path: '',
    component: AuthComponent
  },
  {
    path: 'projects',
    component: ProjectsComponent,
    canActivate: [AdminGuard]
  },
  {
    path: 'timesheets',
    component: TimesheetsComponent,
    canActivate: [AdminGuard]
  },
  {
    path: 'home',
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
