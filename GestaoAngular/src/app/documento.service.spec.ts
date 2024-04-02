/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DocumentoService } from './documento.service';

describe('Service: Documento', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DocumentoService]
    });
  });

  it('should ...', inject([DocumentoService], (service: DocumentoService) => {
    expect(service).toBeTruthy();
  }));
});
