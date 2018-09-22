import { TestBed, inject } from '@angular/core/testing';

import { FollowingsService } from './followings.service';

describe('FollowingsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FollowingsService]
    });
  });

  it('should be created', inject([FollowingsService], (service: FollowingsService) => {
    expect(service).toBeTruthy();
  }));
});
