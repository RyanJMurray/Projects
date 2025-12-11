import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth';

/**
 * The Supermarkets service handles all operations related to
 * supermarkets, including creation, updates, image management,
 * filtering, and pagination.
 */
@Injectable({
  providedIn: 'root',
})
export class Supermarkets {

  /** The base URL for all supermarket-related API requests. */
  private baseUrl = 'http://localhost:5000/api/v1/supermarkets';

  /**
   * The constructor for the Supermarkets service.
   * @param http Used to perform HTTP requests to the backend API.
   * @param authService Provides JWT authentication headers for secure requests.
   */
  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) {}

  /**
   * Retrieves a paginated list of all supermarkets with optional
   * filters and sorting options.
   * @param page The current page number to retrieve.
   * @param filters An object containing filter fields such as name, location, and sorting.
   */
  getSupermarkets(page: number, filters: any): Observable<any> {
    let params = new HttpParams()
      .set('page', page.toString())
      .set('sort_field', filters.sort_field)
      .set('sort_by', filters.sort_by);

    if (filters.name) params = params.set('name', filters.name);
    if (filters.location) params = params.set('location', filters.location);

    return this.http.get<any>(`${this.baseUrl}/`, {
      headers: this.authService.getAuthHeaders(),
      params,
    });
  }

  /**
   * Retrieves a paginated list of supermarkets owned by the logged-in user.
   * @param page The page number of supermarkets to retrieve.
   */
  getMySupermarkets(page: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/mine?page=${page}`, {
      headers: this.authService.getAuthHeaders(),
    });
  }

  /**
   * Updates a specific field of a supermarket.
   * Uses multipart/form-data to allow file or text field updates.
   * @param id The unique identifier of the supermarket.
   * @param field The field name to update (e.g. name, location).
   * @param value The new value for the specified field.
   */
  updateSupermarket(id: string, field: string, value: any): Observable<any> {
    const formData = new FormData();
    formData.append(field, value);
    return this.http.put(`${this.baseUrl}/${id}`, formData, {
      headers: this.authService.getAuthHeaders(),
    });
  }

  /**
   * Uploads a new image for a specific supermarket.
   * @param id The unique identifier of the supermarket.
   * @param file The image file to upload.
   */
  uploadSupermarketImage(id: string, file: File): Observable<any> {
    const formData = new FormData();
    formData.append('supermarket_image', file);
    return this.http.put(`${this.baseUrl}/${id}`, formData, {
      headers: this.authService.getAuthHeaders(),
    });
  }

  /**
   * Removes the image associated with a supermarket by setting
   * its `supermarket_image` field to null.
   * @param id The unique identifier of the supermarket.
   */
  removeSupermarketImage(id: string): Observable<any> {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${this.authService.getToken()}`,
      'Content-Type': 'application/json',
    });

    return this.http.put(`${this.baseUrl}/${id}`, { supermarket_image: null }, { headers });
  }

  /**
   * Creates a new supermarket using the provided form data.
   * @param data The supermarket details, including name, location, contact, and optional image.
   */
  createSupermarket(data: any): Observable<any> {
    const formData = new FormData();
    formData.append('name', data.name);
    formData.append('location', data.location);
    formData.append('contact', data.contact);
    if (data.image) formData.append('supermarket_image', data.image);

    return this.http.post<any>(`${this.baseUrl}/`, formData, {
      headers: this.authService.getAuthHeaders(),
    });
  }

  /**
   * Deletes a supermarket by its unique identifier.
   * @param id The ID of the supermarket to delete.
   */
  deleteSupermarket(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`, {
      headers: this.authService.getAuthHeaders(),
    });
  }
}
