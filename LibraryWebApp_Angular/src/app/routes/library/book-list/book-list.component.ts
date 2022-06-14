import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DtoBook } from 'src/app/rest/dto/DtoBook';
import { BookService } from 'src/app/rest/services/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html'
})
export class BookListComponent implements OnInit {
  
  @Input()
  books: DtoBook[] = [];

  constructor(private _bookService: BookService,
              private router: Router){}
  
  ngOnInit(): void {}

  public editBook(event: Event, id: number) {
    event.stopPropagation()
    this.router.navigate(['book', id, 'edit'])
  }

  public removeBook(event: Event, id: number) {
    event.stopPropagation()
    this.router.navigate(['book', id, 'delete'])
  }

}
