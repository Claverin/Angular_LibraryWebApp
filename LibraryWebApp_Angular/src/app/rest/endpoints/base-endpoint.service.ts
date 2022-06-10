import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseEndpointService {

  constructor(protected client: HttpClient) { }
  base_url = "http://localhost:5135/api/"

  protected get(url: string): Observable<any> {
    return this.client.get(this.base_url + url)
  }

  protected post(url: string, body: any): Observable<any>
  {
    return this.client.post(this.base_url + url, body)
  }
}