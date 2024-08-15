import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-Menu',
  templateUrl: './Menu.component.html',
  styleUrls: ['./Menu.component.css']
})
export class MenuComponent implements OnInit {
  isOpen = false;

  toggle() {
    this.isOpen = !this.isOpen;
  }
  constructor(
    private router: Router) { }

  ngOnInit() {
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

}
