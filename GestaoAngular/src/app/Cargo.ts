import { DecimalPipe } from "@angular/common";

export class Cargo {
    id!: number;
    descricao!: string;
    valor!: number;
    dataEntrada!: Date;
    dataSaida!: Date;
    informacoesSetor!: number; 
}