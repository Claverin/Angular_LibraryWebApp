import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { environment } from "../../../environments/environment";
import { Book } from "../model/Book";
import { DtoBook } from "../dto/DtoBook";

@Injectable({ providedIn: "root" })
export class BookService {
  private readonly apiUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.apiUrl}/books`);
  }

  getBook(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/books/${id}`);
  }

  addBook(dto: DtoBook): Observable<Book> {
    return this.http.post<Book>(`${this.apiUrl}/books`, dto);
  }

  editBook(id: number, dto: DtoBook): Observable<Book> {
    return this.http.patch<Book>(`${this.apiUrl}/books/${id}`, dto);
  }

  removeBook(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/books/${id}`);
  }
}
