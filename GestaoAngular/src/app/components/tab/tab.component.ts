import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SearchService } from '../../search.service';
@Component({
  selector: 'app-tab',
  templateUrl: './tab.component.html',
  styleUrls: ['./tab.component.css'],
})
export class TabComponent implements OnInit {
  isOpen = false;
  searchTerm: string = '';
  currentPage: string = 'home';

  constructor(
    private searchService: SearchService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  toggle() {
    this.isOpen = !this.isOpen;
  }

  openPage(page: string) {
    let url: string;
    switch (page) {
      case 'home':
        url = '/';
        break;
      case 'duvidas':
        url = '/duvidas';
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

  onSearch() {
    this.searchService.setSearchTerm(this.searchTerm);
    this.router.navigate(['/duvidas']); // Navegar para a página de dúvidas
  }
}
