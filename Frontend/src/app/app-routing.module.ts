import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { UserCrudComponent } from './views/user-crud/user-crud.component';
import { UserFormComponent } from './components/user/user-form/user-form.component';


const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "user", component: UserCrudComponent },
  { path: "user/create", component: UserFormComponent },
  { path: "user/update/:id", component: UserFormComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
