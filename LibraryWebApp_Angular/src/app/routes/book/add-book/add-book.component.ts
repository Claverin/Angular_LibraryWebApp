import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Book } from 'src/app/rest/model/Book';
import { BookService } from 'src/app/rest/services/book.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styles: [
  ]
})
export class AddBookComponent implements OnInit {

  @Input()
  bookId: number | null = null

  bookForm = this.fb.group({
    title: [''],
    genre: [''],
    author: [''],
    release_date: [''],
    description: [''],
    image: ['']
  });

  constructor(private _bookService: BookService,
              private fb: FormBuilder,
              private _modal: NgbModal) { }

  ngOnInit(): void {
    if(this.bookId) {
      this._bookService.getBook(this.bookId!).subscribe((data: Book) => {
      })
    }
  }

  public onSubmit(): void {
  }

  public abort(): void {
    this._modal.dismissAll()
  }
}
