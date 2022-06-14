import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ModalContainerComponent } from './modal-container/modal-container.component';

const routes: Routes = [
  { path: '', component: ModalContainerComponent},
  { path: 'edit', component: ModalContainerComponent},
  { path: 'delete', component: ModalContainerComponent}
];

@NgModule({ imports: [RouterModule.forChild(routes)], exports: [RouterModule] })
export class BookRoutingModule { }
