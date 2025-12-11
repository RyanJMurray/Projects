import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AuthService } from './auth';
import { Observable } from 'rxjs';

/**
 * The Items service provides functionality for managing items
 * within supermarkets, including retrieval, creation, updates,
 * and image uploads.
 */
@Injectable({
  providedIn: 'root'
})
export class Items {

  /** The base URL for all item-related API requests. */
  private baseUrl = 'http://localhost:5000/api/v1/items';

  /**
   * The constructor for the Items service.
   * @param http Used to perform HTTP requests to the backend API.
   * @param authService Provides JWT authentication headers for secure requests.
   */
  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) {}

  /**
   * Retrieves items belonging to a specific supermarket.
   * Supports pagination, filtering, and sorting options.
   * @param supermarketId The unique identifier of the supermarket.
   * @param page The page number of results to retrieve.
   * @param filters An object containing filter and sort parameters.
   */
  getItemsBySupermarket(supermarketId: string, page: number, filters: any): Observable<any> {
    let params = new HttpParams()
      .set('page', page)
      .set('supermarket_id', supermarketId);

    Object.keys(filters).forEach(key => {
      if (filters[key]) params = params.set(key, filters[key]);
    });

    return this.http.get<any>(`${this.baseUrl}/supermarket/${supermarketId}`, {
      headers: this.authService.getAuthHeaders(),
      params
    });
  }

  /**
   * Updates a specific field of an item.
   * Uses multipart/form-data to handle both text and image fields.
   * @param itemId The unique identifier of the item to update.
   * @param field The field name to update.
   * @param value The new value for the specified field.
   */
  updateItem(itemId: string, field: string, value: any): Observable<any> {
    const formData = new FormData();
    formData.append(field, value);
    return this.http.put(`${this.baseUrl}/${itemId}`, formData, {
      headers: this.authService.getAuthHeaders()
    });
  }

  /**
   * Uploads a new image for a specific item.
   * @param itemId The unique identifier of the item.
   * @param file The image file to upload.
   */
  uploadItemImage(itemId: string, file: File): Observable<any> {
    const formData = new FormData();
    formData.append('image_url', file);
    return this.http.put(`${this.baseUrl}/${itemId}`, formData, {
      headers: this.authService.getAuthHeaders()
    });
  }

  /**
   * Removes an item's image by setting its `image_url` to null.
   * @param itemId The unique identifier of the item whose image is being removed.
   */
  removeItemImage(itemId: string): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`,
      'Content-Type': 'application/json'
    });
    return this.http.put(`${this.baseUrl}/${itemId}`, { image_url: null }, { headers });
  }

  /**
   * Deletes an item from the database.
   * @param itemId The unique identifier of the item to delete.
   */
  deleteItem(itemId: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${itemId}`, {
      headers: this.authService.getAuthHeaders()
    });
  }

  /**
   * Creates a new item within a supermarket.
   * @param supermarketId The unique identifier of the supermarket where the item belongs.
   * @param newItem The item details, including name, price, stock, and description.
   */
  createItem(supermarketId: string, newItem: any): Observable<any> {
    const formData = new FormData();
    formData.append('name', newItem.name);
    formData.append('price', newItem.price);
    formData.append('stock', newItem.stock);
    formData.append('category', newItem.category);
    formData.append('description', newItem.description);
    formData.append('supermarket_id', supermarketId);

    return this.http.post(this.baseUrl + '/', formData, {
      headers: this.authService.getAuthHeaders()
    });
  }
}
