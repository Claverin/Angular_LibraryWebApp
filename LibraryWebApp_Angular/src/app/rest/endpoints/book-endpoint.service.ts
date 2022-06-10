import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../model/Book';
import { BaseEndpointService } from './base-endpoint.service';

@Injectable({
  providedIn: 'root'
})
export class BookEndpointService extends BaseEndpointService{

  constructor(client: HttpClient)
  {
    super(client)
  }

  url = "book"

  getOne(id: Number): Observable<Book>
  {
    return this.get(this.url + "/" + id)
  }

  getAll(): Observable<Book[]> {
    return this.get(this.url)
  }

  create(book: Book): Observable<Book> {
    return this.post(this.url, book)
  }
}
