import { Cargo } from "./Cargo";

export class Pessoa {
    id!: number;
    nome!: string;
    sobrenome!: string;
    endereco!: string;
    dataNascimento!: Date;
    informacoesCargo!: Cargo; 
}