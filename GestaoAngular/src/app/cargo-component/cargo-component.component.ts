import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cargo } from '../Cargo';
import { CargoService } from '../cargo.service';
import { SetoresEmpresa } from '../Setor';

@Component({
  selector: 'app-cargo-component',
  templateUrl: './cargo-component.component.html',
  styleUrls: ['./cargo-component.component.css']
})
export class CargoComponent implements OnInit {
  formulario: any;
  setoresEmpresa = SetoresEmpresa;
  tituloFormularioCargo!: string;
  cargos!: Cargo[];
  nomeCargo!: string;
  cargoId!: number;
  enumKeys: any;

  visibilidadeTabela: boolean = true;
  visibilidadeFormulario: boolean = false;
  panelOpenState = false;
  modalRef!: BsModalRef;
  getDescricaoSetor(valor: number): string {
    return SetoresEmpresa[valor];
  }

  constructor(private cargoService: CargoService,
    private modalService: BsModalService) { }

  ngOnInit(): void { 
    this.enumKeys = Object.keys(SetoresEmpresa).filter(key => !isNaN(Number(SetoresEmpresa[key as any])));
    this.carregarCargos();
  }

  ExibirFormularioAtualizacao(id: any): void {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.cargoService.GetCargo(id).subscribe(resultado => {
      if (resultado) { // Verificação de nulidade
          this.tituloFormularioCargo = `Atualizar ${resultado.descricao}`;
        this.formulario = new FormGroup({
          id: new FormControl(resultado.id),
          descricao: new FormControl(resultado.descricao),
          informacoesSetor: new FormControl(resultado.informacoesSetor),
          valor: new FormControl(resultado.valor),
          dataEntrada: new FormControl(resultado.dataEntrada),
          dataSaida: new FormControl(resultado.dataSaida)
        });
      }
    });
  }

  ExibirFormularioCadastro(): void {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.tituloFormularioCargo = 'Cadastre um cargo';
    this.formulario = new FormGroup({
      descricao: new FormControl(null),
      valor: new FormControl(null),
      dataEntrada: new FormControl(null),
      informacoesSetor: new FormControl(null),
      dataSaida: new FormControl(null),
    });
  }

  EnviarFormulario(): void {
    const cargo: Cargo = this.formulario.value;
    console.log(cargo);
    if (cargo.id > 0) {
      this.cargoService.AtualizarCargo(cargo).subscribe(resultado => {
        this.visibilidadeFormulario = false;
        this.visibilidadeTabela = true;
        alert('Cargo atualizado com sucesso');
        this.cargoService.GetCargos().subscribe(registros =>{
          this.cargos = registros;
        });
      });
    } else {
      this.cargoService.SalvarCargo(cargo).subscribe(resultado => {
        this.visibilidadeFormulario = false;
        this.visibilidadeTabela = true;
        alert('Cargo inserido com sucesso');
        this.cargoService.GetCargos().subscribe(registros =>{
          this.cargos = registros;
        });
      });
    }
  }

  Voltar(): void {
    this.visibilidadeTabela = true;
    this.visibilidadeFormulario = false;
  }

  ExibirConfirmacaoExclusao(id: any, nomeCargo: any, conteudoModal: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(conteudoModal);
    this.cargoId = id;
    this.nomeCargo = nomeCargo;
  }

  ExcluirCargo(id: any): void {
    this.cargoService.ExcluirCargo(id).subscribe(resultado => {
      this.modalRef.hide();
      alert('Cargo excluído com sucesso');
      this.carregarCargos();
    });
  }

  private carregarCargos(): void {
    this.cargoService.GetCargos().subscribe(registros => {
      this.cargos = registros;
    });
  }
}
