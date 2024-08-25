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

  // questions = [
  //   { title: 'O que é Angular?', body: 'Angular é um framework de desenvolvimento de aplicações web.' },
  //   { title: 'Como funciona a integração com back-end?', body: 'A integração é feita através de APIs RESTful.' },
  //   { title: 'O que é dockerização?', body: 'Dockerização é o processo de empacotar uma aplicação em um container.' },
    // ... mais perguntas
  // ];
  // searchTerm: string = '';




  ngOnInit() {
    // Define a aba inicial
    this.tabService.setCurrentPage('home');
  }

  // getFilteredQuestions() {
  //   return this.questions.filter(question => 
  //     question.title.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
  //     question.body.toLowerCase().includes(this.searchTerm.toLowerCase())
  //   );
  // }
}
