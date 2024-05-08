import { Component, OnInit } from '@angular/core';
import { TabService } from '../tab.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tab',
  templateUrl: './tab.component.html',
  styleUrls: ['./tab.component.css']
})
export class TabComponent implements OnInit {

  currentPage: string = 'home';

  constructor(private tabService: TabService,private router: Router) { }

  ngOnInit(): void {
    this.tabService.currentPage.subscribe(page => {
      this.currentPage = page;
    });
  }

  openPage(page: string) {
    
  // this.tabService.setCurrentPage(page);
    let url: string;
    switch (page) {
      case 'home':
        url = '/';
        break;
      case 'documentos':
        url = '/documento';
        break;
      case 'pessoa':
        url = '/pessoa';
        break;
      case 'cargos':
        url = '/cargo';
        break;
      default:
        url = '/';
    }
    this.router.navigate([url]);
  }
  //toggleDropdown() {
  //  this.dropdownOpen = !this.dropdownOpen;
  //}
}
