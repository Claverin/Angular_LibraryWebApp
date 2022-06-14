import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DtoBook } from '../dto/DtoBook';
import { Book } from '../model/Book';
import { BaseEndpointService } from './base-endpoint.service';

@Injectable({
  providedIn: 'root'
})
export class BookEndpointService extends BaseEndpointService
{
    url = "book/"

    constructor(client: HttpClient) {
        super(client)
    }

    getOne(id: Number): Observable<Book>
    {
        return this.get(this.url + id)
    }

    getAll(): Observable<DtoBook[]>
    {
        return this.get(this.url)
    }

    create(book: Book): Observable<Book>
    {
        return this.post(this.url, book)
    }

    update(book: Book) {
        this.patch(this.url, book)
    }

    remove(id: Number)
    {
        this.delete(this.url + id)
    }
}
