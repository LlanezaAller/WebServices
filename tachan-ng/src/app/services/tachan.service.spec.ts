import { TestBed, inject } from '@angular/core/testing';

import { TachanService } from './tachan.service';

describe('TachanService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TachanService]
    });
  });

  it('should be created', inject([TachanService], (service: TachanService) => {
    expect(service).toBeTruthy();
  }));
});
