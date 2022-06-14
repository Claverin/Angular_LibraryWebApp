import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { DtoBook } from 'src/app/rest/dto/DtoBook';
import { BookService } from 'src/app/rest/services/book.service';
import { BOOKS } from 'src/app/test/mockBook';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styles: []
})
export class LibraryComponent implements OnInit {

  books: DtoBook[] = [];

  constructor(private _bookService: BookService,
    private router: Router){}
  
  ngOnInit(): void {
    this._bookService.getAllBooks().subscribe((data:DtoBook[])=>{
        this.books = data;
    })
    this.books = BOOKS
  }

  public toCreateBook(): void {
    this.router.navigate(['book/create'])
  }
}