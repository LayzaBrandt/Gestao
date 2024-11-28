import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormControl, FormArray, FormBuilder} from '@angular/forms';
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
  formulario!: FormGroup;
  tituloFormulario!: string;
  pessoas!: Pessoa[];
  nomePessoa!: string;
  pessoaId!: number;
  listaCargos: Array<any> = [];
  visibilidadeTabela: boolean = true;
  visibilidadeFormulario: boolean = false;
  modalRef!: BsModalRef;

  constructor(
    private fb: FormBuilder,
    private pessoaService: PessoaService,
    private cargoService: CargoService,
    private modalService: BsModalService
  ) {

    this.formulario = this.fb.group({
      id: [0],
      nome: [''],
      sobrenome: [''],
      idPessoaXCargos: this.fb.array([]),
    });
    
  }


  ngOnInit(): void {
    this.pessoaService.GetPessoas().subscribe((resultado) => {
      console.log(resultado);
      this.pessoas = resultado;
      console.log(this.pessoas);
    });
    this.cargoService.GetCargos().subscribe((resultado) => {
      this.listaCargos = resultado;
    });
  }

  ExibirFormularioCadastro(): void {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.tituloFormulario = 'Nova Pessoa';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      sobrenome: new FormControl(null),
      idPessoaXCargos: new FormArray([]), 
    });
  }

  ExibirFormularioAtualizacao(id: any): void {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.pessoaService.GetPessoa(id).subscribe((resultado) => {
        this.tituloFormulario = `Atualizar ${resultado.nome} ${resultado.sobrenome}`;
        this.formulario = new FormGroup({
            id: new FormControl(resultado.id),
            nome: new FormControl(resultado.nome),
            sobrenome: new FormControl(resultado.sobrenome),
            idPessoaXCargos: new FormArray([]),
        });

        if (resultado.idPessoaXCargos && resultado.idPessoaXCargos.length > 0) {
            resultado.idPessoaXCargos.forEach((cargo) => {
                this.addCargo(cargo); 
            });
        }
    });
}


get cargos(): FormArray {
  return this.formulario.get('idPessoaXCargos') as FormArray;
}


addCargo(cargo?: any): void {
    const cargosFormArray = this.formulario.get('idPessoaXCargos') as FormArray;
    cargosFormArray.push(new FormGroup({
        idCargo: new FormControl(cargo ? cargo.idCargo : ''),
    }));

}

  removeCargo(index: number): void {
    this.cargos.removeAt(index);
  }

  EnviarFormulario(): void {
    const pessoa: Pessoa = this.formulario.value;
    const cargosIds: number[] = this.cargos.controls.map((cargo) => cargo.value.idCargo); 
    if (pessoa.id > 0) {
        this.pessoaService.AtualizarPessoa(pessoa, cargosIds).subscribe(
            (resultado) => {
                this.visibilidadeFormulario = false;
                this.visibilidadeTabela = true;
                alert('Pessoa atualizada com sucesso');
                this.pessoaService.GetPessoas().subscribe((registros) => {
                    this.pessoas = registros;
                });
            },
            (error) => {
                alert('Erro ao atualizar a pessoa: ' + error.message);
            }
        );
    } else {
        this.pessoaService.SalvarPessoa(pessoa, cargosIds).subscribe(
            (resultado) => {
                this.visibilidadeFormulario = false;
                this.visibilidadeTabela = true;
                alert('Pessoa inserida com sucesso');
                this.pessoaService.GetPessoas().subscribe((registros) => {
                    this.pessoas = registros;
                });
            },
            (error) => {
              if(cargosIds.length == 0){
                alert('Erro ao inserir a pessoa: é necessário ter ao menos um cargo cadastrado!');
              }
              else {
                alert('Erro ao inserir a pessoa: ' + error.message);
              }
            }
        );
    }
}


  Voltar(): void {
    this.visibilidadeTabela = true;
    this.visibilidadeFormulario = false;
  }

  ExibirConfirmacaoExclusao(id: any, nomePessoa: any, conteudoModal: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(conteudoModal);
    this.pessoaId = id;
    this.nomePessoa = nomePessoa;
  }

  ExcluirPessoa(id: any): void {
    this.pessoaService.ExcluirPessoa(id).subscribe((resultado) => {
      this.modalRef.hide();
      alert('Pessoa excluída com sucesso');
      this.pessoaService.GetPessoas().subscribe((registros) => {
        this.pessoas = registros;
      });
    });
  }
}
