import { Component, OnInit } from '@angular/core';
import { Book } from '../../../rest/model/Book';
import { BookService } from '../../../rest/services/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

    book!: Book;
    constructor(private _bookService: BookService)
    {

    }

    ngOnInit(): void
    {
        this._bookService.getBook(1).subscribe((data: any) => {
            this.book = data
        })
    }
}
