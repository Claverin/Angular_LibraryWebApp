import { Component, OnInit } from '@angular/core';
import { BookApiService, BookResponse } from './rest/book-api.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
    books: BookResponse[] = [];
    loading = false;
    error = '';

    constructor(private api: BookApiService) { }

    ngOnInit() {
        this.load();
    }

    load() {
        this.loading = true;
        this.error = '';
        this.api.getAll().subscribe({
            next: (res) => { this.books = res; this.loading = false; },
            error: (err) => { this.error = 'Cannot load books.'; console.error(err); this.loading = false; }
        });
    }
}