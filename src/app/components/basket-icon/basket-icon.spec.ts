import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasketIcon } from './basket-icon';

describe('BasketIcon', () => {
  let component: BasketIcon;
  let fixture: ComponentFixture<BasketIcon>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BasketIcon]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BasketIcon);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
