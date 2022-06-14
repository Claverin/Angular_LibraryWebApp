import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BookService } from 'src/app/rest/services/book.service';

@Component({
  selector: 'app-delete-book',
  templateUrl: './delete-book.component.html'
})
export class DeleteBookComponent implements OnInit {

  @Input()
  bookId!: number

  constructor(private _bookService: BookService,
    private modal: NgbModal) { }

  ngOnInit(): void {
  }

  public deleteBook() {
      this._bookService.removeBook(this.bookId)
      this.modal.dismissAll()
  }

  public dissmiss() {
    this.modal.dismissAll()
  }
}
