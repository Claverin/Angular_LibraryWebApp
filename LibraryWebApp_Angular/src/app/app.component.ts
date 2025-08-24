import { HttpClient } from "@angular/common/http";
import { Component, inject, OnInit } from "@angular/core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styles: [],
})
export class AppComponent implements OnInit {
  private http = inject(HttpClient);
  title = "Library Web App";

  ngOnInit(): void {
    this.http.get("https://localhost:5001/api/members").subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (error) => {
        console.log(error);
      },
      complete: () => {
        console.log("Request completed");
      },
    });
  }
}
