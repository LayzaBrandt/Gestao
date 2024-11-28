import { Cargo } from "./Cargo";

export class Pessoa {
    id!: number;
    nome!: string;
    sobrenome!: string;
    idPessoaXCargos?: PessoaXCargo[];
}

export interface PessoaXCargo {
    idPessoa: number;
    idCargo: number;
    descricaoCargo: string;
    cargos: Cargo;
}
