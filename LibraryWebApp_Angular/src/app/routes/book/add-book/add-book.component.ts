import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Book } from 'src/app/rest/model/Book';
import { BookService } from 'src/app/rest/services/book.service';
import { DtoBook } from '../../../rest/dto/DtoBook';
import { Author } from '../../../rest/model/Author';
import { Genre } from '../../../rest/model/Genre';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styles: [
  ]
})
export class AddBookComponent implements OnInit {

  @Input()
  bookId: number | null = null


  book: Book = {} as Book
  authorCounter = 1
  genreCounter = 1
  bookForm = this.fb.group({
    title: [''],
    genre: this.fb.group({
        genre0: [''],
    }),
    author: this.fb.group({
        name0: [''],
        surname0: [''],
    }),
    release_date: [''],
    description: [''],
    image: ['']
  });

  constructor(private _bookService: BookService,
              private fb: FormBuilder,
      private _modal: NgbModal) {
      this.book.title = ''
      this.book.authors = [{ id: -1, name: '', surname: '' }]
      this.book.description = ''
      this.book.image = ''
      this.book.releaseDate = new Date()
      this.book.genres = [{ id: -1, name: '' }]
  }

    ngOnInit(): void {
   
      if (this.bookId) {
          this._bookService.getBook(this.bookId!).subscribe((data: Book) => {
              this.book = data;
              this.bookForm.controls['title'].setValue(data.title);

              this.bookForm.controls['release_date'].setValue(data.releaseDate.toString())
              this.bookForm.controls['description'].setValue(data.description)
              this.bookForm.controls['image'].setValue(data.image)
              this.genreCounter = this.book.genres.length
              this.authorCounter = this.book.authors.length
              let author = (this.bookForm.get('author')) as FormGroup
              data.authors.forEach((it, index) => {
                  author.addControl("name" + index, new FormControl(it.name))
                  author.addControl("surname" + index, new FormControl(it.surname))
              })
              let genre = (this.bookForm.get('genre')) as FormGroup
              data.genres.forEach((it, index) => {
                  genre.addControl("genre" + index, new FormControl(it.name))
              })
          })
      }
  }

    public onSubmit(): void {
        if (this.bookId == null) {
            this._bookService.addBook(this.book)
        } else {
            this._bookService.editBook(this.book)
        }
        this._modal.dismissAll()
  }

  public abort(): void {
    this._modal.dismissAll()
  }

    public addAuthor() {
        let author = (this.bookForm.get('author')) as FormGroup
        author.addControl("name" + this.authorCounter, new FormControl())
        author.addControl("surname" + this.authorCounter, new FormControl())
 
        this.book.authors.push({
            id: -1,
            name: '',
            surname: ''
        })
        this.authorCounter += 1
    }
    public removeAuthor() {
        let author = (this.bookForm.get('author')) as FormGroup
        if (this.authorCounter != 1) {
            this.authorCounter -= 1
            author.removeControl("name" + this.authorCounter)
            author.removeControl("surname" + this.authorCounter)
            this.book.authors.pop()
        }
    }
    public addGenre() {
        let genre = (this.bookForm.get('genre')) as FormGroup
        genre.addControl("genre" + this.genreCounter, new FormControl())
        this.book.genres.push({
            id: -1,
            name: ''
        })
        this.genreCounter += 1
    }
    public removeGenre() {
        let author = (this.bookForm.get('genre')) as FormGroup
        if (this.genreCounter != 1) {
            this.genreCounter -= 1
            author.removeControl("genre" + this.genreCounter)
            this.book.genres.pop()
        }
    }

}
