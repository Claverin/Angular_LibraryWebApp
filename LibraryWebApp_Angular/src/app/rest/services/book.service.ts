import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookEndpointService } from '../endpoints/book-endpoint.service';
import { Book } from '../model/Book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private _bookEndpointService: BookEndpointService) { }

  public getBook(id: Number): Observable<Book>{
    return this._bookEndpointService.getOne(id)
  }

  public getAllBooks(): Observable<Book[]> {
    return this._bookEndpointService.getAll()
  }

  public addBook(book: Book) {
    this._bookEndpointService.create(book)
  }

  public editBook(book: Book) {
    this._bookEndpointService.update(book)
  }

  public removeBook(id: number) {
    this._bookEndpointService.remove(id);
  }

}
