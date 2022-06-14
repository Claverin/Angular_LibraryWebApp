import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'book'
  },
  {
    path: 'book',
    children: [
      {
        path: '',
        loadChildren: async () =>
          (await import('./library/library.module')).LibraryModule,
      }, 
      {
        path: ":id",
        loadChildren: async () =>
          (await import("./book/book.module")).BookModule,
      }
    ],
  },
];

@NgModule({ imports: [RouterModule.forRoot(routes)], exports: [RouterModule] })
export class RoutingModule { }
