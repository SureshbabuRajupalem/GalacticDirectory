import { TestBed, inject } from '@angular/core/testing';

import { GDService } from './gd.service';

describe('GalacticDirService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GDService]
    });
  });

  it('should be created', inject([GDService], (service: GDService) => {
    expect(service).toBeTruthy();
  }));
});
