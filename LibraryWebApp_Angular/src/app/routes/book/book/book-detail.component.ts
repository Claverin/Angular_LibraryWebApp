import { Component, Input, OnInit } from '@angular/core';
import { BOOKS } from 'src/app/test/mockBook';
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

        this.book = {id: 1,
                title: 'Dziady', author: 'Adam Mickiewicz', 
                description: 'Ksiazka z epoki romantyzmu', 
                releaseDate: new Date(1850, 10, 1), genre: 'dramat',
                image: 'default.jpg'}
    }
}
