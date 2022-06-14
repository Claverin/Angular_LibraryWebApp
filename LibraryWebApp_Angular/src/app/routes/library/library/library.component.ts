import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { DtoBook } from 'src/app/rest/dto/DtoBook';
import { BookService } from 'src/app/rest/services/book.service';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styles: []
})
export class LibraryComponent implements OnInit {

  books: DtoBook[] = [];

  isLoaded = false

  constructor(private _bookService: BookService,
    private router: Router){}
  
  ngOnInit(): void {
    this._bookService.getAllBooks().subscribe((data:DtoBook[])=>{
        this.books = data;
        this.isLoaded = true
    })
  }

  public toCreateBook(): void {
    this.router.navigate(['book/create'])
  }
}
