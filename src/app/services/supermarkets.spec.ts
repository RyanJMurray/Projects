import { TestBed } from '@angular/core/testing';

import { Supermarkets } from './supermarkets';

describe('Supermarkets', () => {
  let service: Supermarkets;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Supermarkets);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
