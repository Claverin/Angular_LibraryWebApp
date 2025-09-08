import { Component, Input, OnInit } from "@angular/core";
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { Router } from "@angular/router";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

import { BookService } from "src/app/rest/services/book.service";
import { DtoBook } from "src/app/rest/dto/DtoBook";
import { Author } from "src/app/rest/model/Author";
import { Genre } from "src/app/rest/model/Genre";
import { Book } from "src/app/rest/model/Book";

@Component({
  selector: "app-add-book",
  templateUrl: "./add-book.component.html",
})
export class AddBookComponent implements OnInit {
  @Input() bookId: number | null = null;

  form: FormGroup = this.fb.group({
    title: ["", [Validators.required, Validators.maxLength(200)]],
    description: [""],
    image: [""],
    releaseDate: ["", Validators.required],
    authors: this.fb.array([this.authorGroup()]),
    genres: this.fb.array([this.genreGroup()]),
  });

  get authors(): FormArray {
    return this.form.get("authors") as FormArray;
  }
  get genres(): FormArray {
    return this.form.get("genres") as FormArray;
  }

  constructor(
    private fb: FormBuilder,
    private bookService: BookService,
    private modal: NgbModal,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (this.bookId != null) {
      this.loadForEdit(this.bookId);
    }
  }

  private authorGroup(): FormGroup {
    return this.fb.group({
      name: ["", Validators.required],
      surname: ["", Validators.required],
    });
  }

  private genreGroup(): FormGroup {
    return this.fb.group({
      name: ["", Validators.required],
    });
  }

  addAuthor(): void {
    this.authors.push(this.authorGroup());
  }
  removeAuthor(): void {
    if (this.authors.length > 1) this.authors.removeAt(this.authors.length - 1);
  }

  addGenre(): void {
    this.genres.push(this.genreGroup());
  }
  removeGenre(): void {
    if (this.genres.length > 1) this.genres.removeAt(this.genres.length - 1);
  }

  private loadForEdit(id: number): void {
    this.bookService.getBook(id).subscribe((b: Book) => {
      this.setArray(
        this.authors,
        b.authors.map((a) =>
          this.fb.group({ name: [a.name], surname: [a.surname] })
        )
      );
      this.setArray(
        this.genres,
        b.genres.map((g) => this.fb.group({ name: [g.name] }))
      );

      this.form.patchValue({
        title: b.title,
        description: b.description,
        image: b.image,
        releaseDate: this.asDateInputValue(b.releaseDate),
      });
    });
  }

  private setArray(arr: FormArray, groups: FormGroup[]): void {
    while (arr.length) arr.removeAt(0);
    groups.forEach((g) => arr.push(g));
    if (arr.length === 0) arr.push(this.fb.group({}));
  }

  private asDateInputValue(d: any): string {
    const date = d instanceof Date ? d : new Date(d);
    const y = date.getFullYear();
    const m = (date.getMonth() + 1).toString().padStart(2, "0");
    const day = date.getDate().toString().padStart(2, "0");
    return `${y}-${m}-${day}`;
  }

  private toDto(): DtoBook {
    const v = this.form.value as any;
    const authors: Author[] = (v.authors || []).map(
      (a: any) => ({ name: a.name, surname: a.surname } as Author)
    );
    const genres: Genre[] = (v.genres || []).map(
      (g: any) => ({ name: g.name } as Genre)
    );
    const dto: DtoBook = {
      title: v.title,
      description: v.description || undefined,
      image: v.image || undefined,
      releaseDate: v.releaseDate,
      authors,
      genres,
    };
    return dto;
  }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const payload = this.toDto();

    const req$ =
      this.bookId == null
        ? this.bookService.addBook(payload)
        : this.bookService.editBook(this.bookId, payload);

    req$.subscribe({
      next: () => {
        this.modal.dismissAll();
        this.router.navigate(["/book"]);
      },
      error: (e: any) => {
        console.error(e);
      },
    });
  }

  abort(): void {
    this.modal.dismissAll();
  }
}
