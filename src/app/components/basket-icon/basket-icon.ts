import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketService } from '../../services/basket';
import { Router } from '@angular/router';

/**
 * The BasketIcon component displays a small basket icon
 * showing the total number of items currently in the user's basket.
 */
@Component({
  selector: 'app-basket-icon',
  imports: [CommonModule],
  templateUrl: './basket-icon.html',
  styleUrl: './basket-icon.css',
})
export class BasketIcon {

  /**
   * The total number of items in the basket.
   */
  itemCount = 0;

  /**
   * The constructor for the BasketIcon component.
   * @param basketService Injected service responsible for managing basket data.
   * @param router Used for navigating to the Basket page.
   */
  constructor(private basketService: BasketService, private router: Router) {}

  /**
   * On load, the amount of items in the basket are checked and displayed.
   */
  ngOnInit() {
    this.updateCount();

    // Periodically check for updates (simple and effective)
    setInterval(() => this.updateCount(), 500);
  }

  /**
   * Retrieves the current basket contents and updates the total item count.
   */
  updateCount() {
    const basket = this.basketService.getBasket();
    this.itemCount = basket.reduce((sum, item) => sum + item.quantity, 0);
  }

  /**
   * Navigates the user to the Basket page.
   */
  goToBasket() {
    this.router.navigate(['/basket']);
  }
}
