import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PessoaComponent } from './components/pessoa-component/pessoa-component.component';
import { CargoComponent } from './components/cargo-component/cargo-component.component';
import { DocumentoComponent } from './components/documento-component/documento-component.component';
import { LucideAngularModule, Menu } from 'lucide-angular';
import { DuvidasComponent } from './components/ajuda/duvidas.component';

const routes: Routes = [
  { path: 'pessoa', component: PessoaComponent },
  { path: 'cargo', component: CargoComponent },
  { path: 'documento', component: DocumentoComponent },
  { path: 'duvidas', component: DuvidasComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes),LucideAngularModule.pick({ Menu })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
