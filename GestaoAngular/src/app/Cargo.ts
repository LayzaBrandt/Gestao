import { Pessoa } from "./Pessoa";

export class Cargo {
    id!: number;
    descricao!: string;
    valor!: number;
    dataEntrada!: Date;
    dataSaida!: Date;
    informacoesSetor!: number; 
    pessoas?: Pessoa[]; 
}