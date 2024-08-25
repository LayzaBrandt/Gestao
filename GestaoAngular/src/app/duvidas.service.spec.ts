import { TestBed, async, inject } from '@angular/core/testing';
import { DuvidasService } from './duvidas.service';

describe('DuvidasService', () => {
  let service: DuvidasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DuvidasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
