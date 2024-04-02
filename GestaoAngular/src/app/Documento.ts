import { MotivoDesligamento } from "./MotivoDesligamento";
import { Pessoa } from "./Pessoa";

export interface Documento {
    id: number;
    empresa: string | null;
    idPessoa: Pessoa;
    enderecoEmpresa: string | null;
    dataEmissao: Date;
    dataEfetivaDesligamento: Date | null;
    idMotivoDesligamento: number;
  }