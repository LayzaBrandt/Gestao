import { Component, OnInit } from '@angular/core';
import { TabService } from './tab.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'GestaoAngular';
  constructor(private tabService: TabService) { }

  ngOnInit() {
    this.tabService.setCurrentPage('home');
  }

}
