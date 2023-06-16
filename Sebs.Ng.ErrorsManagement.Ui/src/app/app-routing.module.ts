import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorsComponent } from './core/test-errors/test-errors.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { HomeComponent } from './core/home/home.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';

const routes: Routes = [
    {path: '', component: HomeComponent, data: {breadcrumb: 'Home'}},
  {path: 'test-errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
    { 
        //Leave this wildcard last in the routes order because it will catch every path if not
        path: '**', //routes that don't exists
        component: NotFoundComponent,
    }
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })

  export class AppRoutingModule { }