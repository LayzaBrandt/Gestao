import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PessoaService} from './pessoa.service'
import { CargoService} from './cargo.service'
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule} from  'ngx-bootstrap/modal';
import { PessoaComponent } from './components/pessoa-component/pessoa-component.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CargoComponent } from './cargo-component/cargo-component.component';
import { TabService } from './tab.service'; // Importe o serviço
import { DocumentoComponent } from './documento-component/documento-component.component';
import { DocumentoService } from './documento.service';
import { TabComponent } from './tab/tab.component';
import { MatToolbarModule} from '@angular/material/toolbar';
import { MatMenuModule} from '@angular/material/menu';

@NgModule({
  declarations: [		
    AppComponent,
    PessoaComponent,
    CargoComponent,
    DocumentoComponent,
    TabComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    MatExpansionModule,
    ReactiveFormsModule,
    MatDividerModule,
    MatFormFieldModule, 
    MatSelectModule, 
    MatInputModule, 
    FormsModule,
    MatListModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    MatMenuModule,
    ModalModule.forRoot()
  ],
  providers: [HttpClientModule,TabService, PessoaService, CargoService, DocumentoService],
  bootstrap: [AppComponent]
})
export class AppModule { }

