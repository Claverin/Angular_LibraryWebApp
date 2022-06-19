import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookDetailComponent } from './book-details/book-detail.component';
import { BookRoutingModule } from './book-routing.module';
import { ModalContainerComponent } from './modal-container/modal-container.component';
import { AddBookComponent } from './add-book/add-book.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeleteBookComponent } from './delete-book/delete-book.component';

@NgModule({
  declarations: [
    BookDetailComponent,
    ModalContainerComponent,
    AddBookComponent,
    DeleteBookComponent
  ],
  imports: [
    CommonModule,
    BookRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class BookModule { }
