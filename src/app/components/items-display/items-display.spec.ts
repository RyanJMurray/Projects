import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemsDisplay } from './items-display';

describe('ItemsDisplay', () => {
  let component: ItemsDisplay;
  let fixture: ComponentFixture<ItemsDisplay>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItemsDisplay]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemsDisplay);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
