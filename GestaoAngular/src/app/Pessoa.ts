import { Cargo } from "./Cargo";

export class Pessoa {
    id!: number;
    nome!: string;
    sobrenome!: string;
    cargos?: Cargo[];
}

export interface PessoaXCargo {
    idPessoa: number;
    idCargo: number;
}
