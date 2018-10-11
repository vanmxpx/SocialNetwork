import { TestBed, inject } from '@angular/core/testing';

import { AddpostService } from './addpost.service';

describe('AddpostService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AddpostService]
    });
  });

  it('should be created', inject([AddpostService], (service: AddpostService) => {
    expect(service).toBeTruthy();
  }));
});
