import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TabService {

  private currentPageSubject = new BehaviorSubject<string>('home');
  currentPage = this.currentPageSubject.asObservable();

  constructor() { }

  setCurrentPage(page: string) {
    this.currentPageSubject.next(page);
  }
}
