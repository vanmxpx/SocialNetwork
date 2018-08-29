import { TestBed, inject } from '@angular/core/testing';

import { InputDataValidatorService } from './input-data-validator.service';

describe('InputDataValidatorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InputDataValidatorService]
    });
  });

  it('should be created', inject([InputDataValidatorService], (service: InputDataValidatorService) => {
    expect(service).toBeTruthy();
  }));
});
