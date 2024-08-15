import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { PessoaService } from '../../pessoa.service';
import { Pessoa } from '../../Pessoa';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cargo } from '../../Cargo';
import { CargoService } from '../../cargo.service';


@Component({
  selector: 'app-pessoa-component',
  templateUrl: './pessoa-component.component.html',
  styleUrls: ['./pessoa-component.component.css'],
})
export class PessoaComponent implements OnInit {

  formulario: any;
  tituloFormulario!: string;
  pessoas!: Pessoa[];
  nomePessoa!: string;
  pessoaId!: number;
  listaCargos!: Cargo[];
  visibilidadeTabela: boolean = true;
  visibilidadeFormulario: boolean = false;
  panelOpenState = false;
  modalRef!: BsModalRef;
  enumKeys: any;

  constructor(private pessoaService: PessoaService,
    private cargoService: CargoService,
    private modalService: BsModalService) { }
    

  ngOnInit(): void {
    this.pessoaService.GetPessoas().subscribe(resultado => {
        this.pessoas = resultado;
      });
      this.cargoService.GetCargos().subscribe(resultado => {
        this.listaCargos = resultado;
      });
  }

  ExibirFormularioCadastro(): void{
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.tituloFormulario = 'Nova Pessoa';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      sobrenome: new FormControl(null),
      dataNascimento: new FormControl(null), 
      endereco: new FormControl(null), 
      informacoesCargo: new FormControl(null) ,
    });
  }

  ExibirFormularioAtualizacao(id: any): void {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.pessoaService.GetPessoa(id).subscribe(resultado =>{
      console.log(resultado);
      this.tituloFormulario = `Atualizar ${resultado.nome} ${resultado.sobrenome}`;
      this.formulario = new FormGroup({
        id: new FormControl(resultado.id),
        nome: new FormControl(resultado.nome),
        sobrenome: new FormControl(resultado.sobrenome),
        endereco: new FormControl(resultado.endereco),
        dataNascimento: new FormControl(resultado.dataNascimento),
        informacoesCargo: new FormControl(resultado.informacoesCargo)
      })
    })
}


  EnviarFormulario(): void {
    const pessoa: Pessoa = this.formulario.value;
    if(pessoa.id > 0){
      this.pessoaService.AtualizarPessoa(pessoa).subscribe(resultado => {
        this.visibilidadeFormulario = false;
        this.visibilidadeTabela = true;
        alert('Pessoa atualizada com Sucesso');
        this.pessoaService.GetPessoas().subscribe(registros =>{
          this.pessoas = registros;
        });
      });
    }
    else{
    this.pessoaService.SalvarPessoa(pessoa).subscribe(resultado => {
      this.visibilidadeFormulario = false;
      this.visibilidadeTabela = true;
      alert('Pessoa inserida com Sucesso');
      this.pessoaService.GetPessoas().subscribe(registros =>{
        this.pessoas = registros;
      });
    });
  }
  }
  Voltar(): void{
    this.visibilidadeTabela = true;
    this.visibilidadeFormulario = false;
  }

  ExibirConfirmacaoExclusao(id: any, nomePessoa: any, conteudoModal: TemplateRef<any>): void{
    this.modalRef = this.modalService.show(conteudoModal);
    this.pessoaId = id;
    this.nomePessoa = nomePessoa;
  }

  ExcluirPessoa(id: any){
    this.pessoaService.ExcluirPessoa(id).subscribe(resultado =>
      {this.modalRef.hide();
      alert('Pessoa excluída com sucesso');
      this.pessoaService.GetPessoas().subscribe(registros =>{
        this.pessoas = registros;
      })
  })
  }
}