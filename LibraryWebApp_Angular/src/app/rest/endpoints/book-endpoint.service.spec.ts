import { TestBed } from '@angular/core/testing';

import { BookEndpointService } from './book-endpoint.service';

describe('BookEndpointService', () => {
  let service: BookEndpointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookEndpointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
