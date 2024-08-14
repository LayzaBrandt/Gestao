import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DocumentoService } from '../../documento.service'; // Certifique-se de importar o serviço de documento apropriado
import { MotivoDesligamento } from '../../MotivoDesligamento';
import { Documento } from '../../Documento';
import { Pessoa } from '../../Pessoa';
import { PessoaService } from '../../pessoa.service';

@Component({
  selector: 'app-documento-component',
  templateUrl: './documento-component.component.html',
  styleUrls: ['./documento-component.component.css']
})
export class DocumentoComponent implements OnInit {
  formulario: any;
  motivosDesligamento = MotivoDesligamento;
  listaPessoa!: Pessoa[];
  tituloFormularioDocumento!: string;
  documentos!: Documento[];
  nomeDocumento!: string;
  documentoId!: number;
  enumKeys: any;
  pessoaSelecionada: Pessoa | undefined;

  visibilidadeTabela: boolean = true;
  visibilidadeFormulario: boolean = false;
  panelOpenState = false;
  modalRef!: BsModalRef;

  constructor(private documentoService: DocumentoService, private pessoaService: PessoaService,
    private modalService: BsModalService) { }

  async ngOnInit() {
    this.enumKeys = Object.keys(MotivoDesligamento).filter(key => !isNaN(Number(MotivoDesligamento[key as any])));
    await this.documentoService.GetDocumentos().subscribe(async (resultado) => {
      this.documentos = resultado;
      console.log(this.documentos);
    });
    await this.pessoaService.GetPessoas().subscribe(resultado => {
      this.listaPessoa = resultado;
    });
  }
  getDescricaoDocumento(valor: number): string {
    return MotivoDesligamento[valor];
  }

  async ExibirFormularioAtualizacao(id: any) {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.documentoService.GetDocumento(id).subscribe(async resultado => {
      if (resultado) {
        this.tituloFormularioDocumento = `Atualizar Documento`;
        this.pessoaSelecionada = resultado.idPessoa;
        this.formulario = new FormGroup({
          id: new FormControl(resultado.id),
          dataEfetivaDesligamento: new FormControl(resultado.dataEfetivaDesligamento),
          dataEmissao: new FormControl(resultado.dataEmissao),
          empresa: new FormControl(resultado.empresa),
          idMotivoDesligamento: new FormControl(resultado.idMotivoDesligamento),
          enderecoEmpresa: new FormControl(resultado.enderecoEmpresa),
          idPessoa: new FormControl(resultado.idPessoa.nome),

        });
        console.log(this.pessoaSelecionada);
      }
    });
  }

  ExibirFormularioCadastro(): void {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.tituloFormularioDocumento = 'Cadastre um documento';
    this.formulario = new FormGroup({
      dataEfetivaDesligamento: new FormControl(null),
      dataEmissao: new FormControl(null),
      empresa: new FormControl(null),
      idMotivoDesligamento: new FormControl(null),
      enderecoEmpresa: new FormControl(null),
      idPessoa:new FormControl(null),
    });
  }

  EnviarFormulario(): void {
    const documento: Documento = this.formulario.value;
    if (documento.id > 0) {
      this.documentoService.AtualizarDocumento(documento).subscribe(resultado => {
        this.visibilidadeFormulario = false;
        this.visibilidadeTabela = true;
        alert('Documento atualizado com sucesso');
        this.carregarDocumentos();
      });
    } else {
      this.documentoService.SalvarDocumento(documento).subscribe(resultado => {
        this.visibilidadeFormulario = false;
        this.visibilidadeTabela = true;
        alert('Documento inserido com sucesso');
        this.carregarDocumentos();
      });
    }
  }

  Voltar(): void {
    this.visibilidadeTabela = true;
    this.visibilidadeFormulario = false;
  }

  ExibirConfirmacaoExclusao(id: any, nomeDocumento: any, conteudoModal: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(conteudoModal);
    this.documentoId = id;
    this.nomeDocumento = nomeDocumento;
  }

  ExcluirDocumento(id: any): void {
    this.documentoService.ExcluirDocumento(id).subscribe(resultado => {
      this.modalRef.hide();
      alert('Documento excluído com sucesso');
      this.carregarDocumentos();
    });
  }

  private carregarDocumentos(): void {
    this.documentoService.GetDocumentos().subscribe(registros => {
      this.documentos = registros;
    });
  }
}
