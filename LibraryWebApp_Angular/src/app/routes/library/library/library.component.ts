import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Book } from "src/app/rest/model/Book";
import { BookService } from "src/app/rest/services/book.service";

@Component({
  selector: "app-library",
  templateUrl: "./library.component.html",
  styles: [],
})
export class LibraryComponent implements OnInit {
  books: Book[] = [];

  constructor(private _bookService: BookService, private router: Router) {}

  ngOnInit(): void {
    this._bookService.getBooks().subscribe((data: Book[]) => {
      console.log(data);
      this.books = data;
    });
  }

  public toCreateBook(): void {
    this.router.navigate(["book/create"]);
  }
}
