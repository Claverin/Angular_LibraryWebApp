import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface Author { id?: number; name: string; surname: string; }
export interface Genre { id?: number; name: string; }
export interface BookDto {
    title: string;
    description?: string;
    image?: string;
    releaseDate: string;
    authors: Author[];
    genres: Genre[];
}
export interface BookResponse extends BookDto { id: number; }

@Injectable({ providedIn: 'root' })
export class BookApiService {
    private readonly base = environment.apiBaseUrl; // np. http://localhost:8080/api

    constructor(private http: HttpClient) { }

    getAll(): Observable<BookResponse[]> {
        return this.http.get<BookResponse[]>(`${this.base}/books`);
    }
    getOne(id: number): Observable<BookResponse> {
        return this.http.get<BookResponse>(`${this.base}/books/${id}`);
    }
    create(dto: BookDto): Observable<BookResponse> {
        return this.http.post<BookResponse>(`${this.base}/books`, dto);
    }
    update(id: number, dto: Partial<BookDto>): Observable<BookResponse> {
        return this.http.patch<BookResponse>(`${this.base}/books/${id}`, dto);
    }
    remove(id: number): Observable<void> {
        return this.http.delete<void>(`${this.base}/books/${id}`);
    }
}