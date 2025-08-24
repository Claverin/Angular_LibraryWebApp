import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { DtoBook } from "../dto/DtoBook";
import { BookEndpointService } from "../endpoints/book-endpoint.service";
import { Book } from "../model/Book";

@Injectable({
  providedIn: "root",
})
export class BookService {
  constructor(private _bookEndpointService: BookEndpointService) {}

  public getBook(id: Number): Observable<Book> {
    return this._bookEndpointService.getOne(id);
  }

  public getAllBooks(): Observable<DtoBook[]> {
    return this._bookEndpointService.getAll();
  }

  public addBook(book: Book) {
    this._bookEndpointService.create(book).subscribe();
  }

  public editBook(book: Book) {
    this._bookEndpointService.update(book);
  }

  public removeBook(id: number): Observable<any> {
    return this._bookEndpointService.remove(id);
  }
}
