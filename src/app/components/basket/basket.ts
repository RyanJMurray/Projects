import { Component } from '@angular/core';
import { BasketService } from '../../services/basket';
import { CommonModule } from '@angular/common';
import { ProfileService } from '../../services/profile';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

/**
 * The Basket component provides functionality for viewing,
 * updating, and purchasing items in the user's shopping basket.
 */
@Component({
  selector: 'app-basket',
  imports: [CommonModule],
  templateUrl: './basket.html',
  styleUrl: './basket.css',
})
export class Basket {

  /**
   * The current contents of the user's basket.
   */
  basket: any[] = [];

  /**
   * The total cost of all items in the basket.
   */
  total: number = 0;

  /**
   * The constructor for the Basket component.
   * @param router Used for navigation to other components (e.g. Profile).
   * @param basketService Injected service responsible for basket operations.
   * @param profileService Injected service used to retrieve and verify user balance.
   * @param location Used to handle navigation back to the previous page.
   */
  constructor(
    private router: Router,
    private basketService: BasketService,
    private profileService: ProfileService,
    private location: Location
  ) {}

  /**
   * Loads the basket and total cost, when the component is initialised.
   */
  ngOnInit() {
    this.basket = this.basketService.getBasket();
    this.total = this.basketService.getTotal();
  }

  /**
   * Loads the basket and total cost from the BasketService.
   */
  loadBasket() {
    this.basket = this.basketService.getBasket();
    this.total = this.basketService.getTotal();
  }

  /**
   * Increases the quantity of a specific basket item,
   * ensuring it does not exceed available stock.
   * @param item The item object whose quantity is being increased.
   */
  increaseQuantity(item: any) {
    const newQty = item.quantity + 1;
    if (newQty <= item.stock) {
      this.basketService.updateQuantity(item._id, newQty);
      this.loadBasket();
    }
  }

  /**
   * Decreases the quantity of a specific basket item,
   * ensuring it does not go below 1.
   * @param item The item object whose quantity is being decreased.
   */
  decreaseQuantity(item: any) {
    const newQty = item.quantity - 1;
    if (newQty >= 1) {
      this.basketService.updateQuantity(item._id, newQty);
      this.loadBasket();
    }
  }

  /**
   * Removes a specific item from the basket.
   * @param id The unique identifier of the item to remove.
   */
  removeItem(id: string) {
    this.basketService.removeItem(id);
    this.ngOnInit();
  }

  /**
   * Processes the purchase of the basket contents. Steps includes:
   *
   * - Verifies user balance before proceeding.
   * - Prompts the user to confirm purchase.
   * - Clears basket and redirects to Profile on success.
   */
  buyNow() {
    const total = this.basketService.getTotal();

    this.profileService.getAuthenticatedUser().subscribe({
      next: (res) => {
        const balance = res.user.balance ?? 0;

        if (balance < total) {
          alert(`Insufficient balance. You have £${balance.toFixed(2)} but need £${total.toFixed(2)}.`);
          return;
        }

        const confirmed = confirm(`Confirm purchase for £${total.toFixed(2)}?`);
        if (!confirmed) return;

        this.basketService.checkout().subscribe({
          next: () => {
            alert('Purchase successful!');
            this.basketService.clearBasket();
            this.router.navigate(['/profile']);
          },
          error: (err) => {
            console.error(err);
            alert('Failed to complete purchase. Please try again.');
          }
        });
      },
      error: (err) => console.error('Error fetching balance:', err)
    });
  }

  /**
   * Navigates the user back to the previous page.
   */
  back() {
    this.location.back();
  }
}
