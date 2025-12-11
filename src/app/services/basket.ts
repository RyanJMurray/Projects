import { Injectable } from '@angular/core';
import { AuthService } from './auth';
import { HttpClient } from '@angular/common/http';

/**
 * The BasketService manages all shopping basket operations,
 * including adding, updating, and removing items, as well as
 * checking out and storing basket data in local storage.
 */
@Injectable({
  providedIn: 'root',
})
export class BasketService {

  /** The key used to store basket data in local storage. */
  private basketKey = 'basket';

  /** The array of items currently in the user's basket. */
  private items: any[] = [];

  /**
   * The constructor for the BasketService.
   * @param http Used for performing checkout requests to the backend.
   * @param authService Injected authentication service used to attach JWT headers.
   */
  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) {
    // Load existing basket from local storage (if present)
    const saved = localStorage.getItem(this.basketKey);
    this.items = saved ? JSON.parse(saved) : [];
  }

  /**
   * Returns the current list of items in the basket.
   */
  getBasket(): any[] {
    return this.items;
  }

  /**
   * Adds a new item to the basket or updates its quantity if it already exists.
   * Ensures that the quantity never exceeds available stock.
   * @param item The item object to add or update in the basket.
   */
  addItem(item: any): void {
    const existing = this.items.find(i => i._id === item._id);

    if (existing) {
      const newQuantity = existing.quantity + item.quantity;
      existing.quantity = Math.min(newQuantity, item.stock);
    } else {
      this.items.push({ ...item, quantity: Math.min(item.quantity, item.stock) });
    }

    this.saveBasket();
  }

  /**
   * Updates the quantity of an existing item in the basket.
   * Ensures that quantity remains within the quantity limits.
   * @param itemId The unique identifier of the item.
   * @param quantity The new quantity to set.
   */
  updateQuantity(itemId: string, quantity: number): void {
    const item = this.items.find(i => i._id === itemId);
    if (item) {
      item.quantity = Math.max(1, Math.min(quantity, item.stock));
      this.saveBasket();
    }
  }

  /**
   * Removes a specific item from the basket based on its ID.
   * @param itemId The unique identifier of the item to remove.
   */
  removeItem(itemId: string): void {
    this.items = this.items.filter(i => i._id !== itemId);
    this.saveBasket();
  }

  /**
   * Clears all items from the basket and updates local storage.
   */
  clearBasket(): void {
    this.items = [];
    this.saveBasket();
  }

  /**
   * Calculates and returns the total cost of all items in the basket.
   */
  getTotal(): number {
    return this.items.reduce((total, i) => total + i.price * i.quantity, 0);
  }

  /**
   * Submits the current basket as a purchase transaction to the backend.
   * Automatically includes JWT headers for authentication.
   */
  checkout() {
    const headers = this.authService.getAuthHeaders();
    const payload = {
      items: this.items.map(i => ({
        item_id: i._id,
        quantity: i.quantity
      }))
    };

    return this.http.post(`http://localhost:5000/api/v1/transactions/`, payload, { headers });
  }

  /**
   * Saves the current basket to local storage.
   */
  private saveBasket(): void {
    localStorage.setItem(this.basketKey, JSON.stringify(this.items));
  }
}
