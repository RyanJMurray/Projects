import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopSellingChart } from './top-selling-chart';

describe('TopSellingChart', () => {
  let component: TopSellingChart;
  let fixture: ComponentFixture<TopSellingChart>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TopSellingChart]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopSellingChart);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
