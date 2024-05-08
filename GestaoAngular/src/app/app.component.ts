import { Component, OnInit } from '@angular/core';
import { TabService } from './tab.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] // Aqui está a correção
})

export class AppComponent implements OnInit {
  title = 'GestaoAngular';
  constructor(private tabService: TabService) { }

  ngOnInit() {
    // Define a aba inicial
    this.tabService.setCurrentPage('home');
  }
}
