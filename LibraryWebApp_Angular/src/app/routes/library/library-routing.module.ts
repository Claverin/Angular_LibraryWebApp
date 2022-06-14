import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ModalContainerComponent } from '../book/modal-container/modal-container.component';
import { LibraryComponent } from './library/library.component';

const routes: Routes = [
  { path: '', component: LibraryComponent},
  { path: 'create', component: ModalContainerComponent}
  
];

@NgModule({ imports: [RouterModule.forChild(routes)], exports: [RouterModule] })
export class LibraryRoutingModule { }
