import { Component, OnInit } from '@angular/core';
import { SearchService } from '../../search.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-duvidas',
  templateUrl: './duvidas.component.html',
  styleUrls: ['./duvidas.component.css']
})
export class DuvidasComponent implements OnInit {
  questions = [
    { 
      title: 'O que é Gest.este?', 
      body: 'A ideia principal deste projeto é poder adquirir novos conhecimentos em áreas não trabalhadas antes, ou não desenvolvidas desde o início. Pretendo trabalhar na construção de interfaces front-end utilizando Angular, na integração com sistemas back-end, na dockerização e orquestração de containers para ambientes escaláveis, bem como na implementação de funcionalidades para a criação e upload de documentos em formatos como TXT e PDF, utilizando técnicas de manipulação de arquivos e geração de conteúdo dinâmico. Além disso, planejo adotar práticas de versionamento de código com Git, testes automatizados e metodologias ágeis para a possibilidade de desenvolvimento colaborativo.' 
    },
    { 
      title: 'Por que do nome Gest.este?', 
      body: 'O nome surgiu pois queria que o sistema tivesse um nome que soasse profissional e real, mas ao mesmo tempo refletisse o caráter experimental do projeto. Assim, “Gest.este” é uma combinação de “gestão” e “teste”, simbolizando um sistema de gestão pessoal em um ambiente de teste.' 
    },
    { 
      title: 'Como o banco foi pensado?', 
      body: 'A seguir, vou apresentar a concepção inicial do banco de dados para a persistência de dados, conforme idealizado até o momento, abrangendo a modelagem de entidades, normalização e definição de relacionamentos. O banco de dados poderá sofrer alterações conforme novas necessidades surgirem ou problemas forem encontrados no caminho.',
      image: '../../../assets/img/IdealizacaoBancoDados.png' // Caminho para a imagem
    },
    {
      title:'Para mais informações entre em contato:',
       body: '<a href="mailto:LayzaBrandt@gmail.com">GesTeste@GestEste.com.br</a>' 
    }
  ];

  searchTerm: string = '';
  filteredQuestions = this.questions;

  constructor(private searchService: SearchService) {}

  ngOnInit(): void {
    this.searchService.searchTerm$.subscribe(term => {
      this.searchTerm = term;
      this.filterQuestions();
    });
  }

  filterQuestions() {
    this.filteredQuestions = this.questions.filter(question => 
      question.title.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      question.body.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
