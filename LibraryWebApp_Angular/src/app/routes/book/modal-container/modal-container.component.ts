import { Component, OnDestroy } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { BookDetailComponent } from '../book-details/book-detail.component';
import { AddBookComponent } from '../add-book/add-book.component';
import { DeleteBookComponent } from '../delete-book/delete-book.component';

@Component({
  selector: 'app-modal-container',
  template: ''
})
export class ModalContainerComponent implements OnDestroy {
  destroy = new Subject<any>();
  currentDialog: any | null = null;

  constructor(
    private modalService: NgbModal,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    let component: any = BookDetailComponent
    let url = router.url
    if(url.includes('create')) {
      component = AddBookComponent
    } else if(url.includes('edit')) {
      component = AddBookComponent
    } else if(url.includes('delete')) {
      component = DeleteBookComponent
    }
    route.params.pipe(takeUntil(this.destroy)).subscribe(params => {
        this.currentDialog = this.modalService.open(component, {centered: true});
        this.currentDialog.componentInstance.bookId = params['id']
        this.currentDialog.result.then((result: any) => {
            router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
                this.router.navigate(['/']);
            });
        }, (reason: any)=> {
            router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
                this.router.navigate(['/']);
            });
        });
    });
  }

  ngOnDestroy() {
    this.destroy.next(1)
  }
}