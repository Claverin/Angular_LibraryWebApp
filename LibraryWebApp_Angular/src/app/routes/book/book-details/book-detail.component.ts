import { Component, Input, OnInit } from '@angular/core';
import { Book } from '../../../rest/model/Book';
import { BookService } from '../../../rest/services/book.service';

@Component({
    selector: 'app-book',
    templateUrl: './book-detail.component.html',
    styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {

    @Input()
    bookId!: number;

    book!: Book

    constructor(private _bookService: BookService) {}

    ngOnInit(): void
    {
        this._bookService.getBook(this.bookId).subscribe((data: any) => {
            this.book = data
        })
    }

}
