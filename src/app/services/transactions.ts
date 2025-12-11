import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth';
import { Observable } from 'rxjs';

/**
 * The Transactions service provides access to transaction-related
 * operations, including retrieving user purchase history and
 * top-selling items across supermarkets.
 */
@Injectable({
  providedIn: 'root',
})
export class Transactions {

  /**
   * The constructor for the Transactions service.
   * @param http Used to perform HTTP requests to the backend API.
   * @param authService Provides JWT authentication headers for secure requests.
   */
  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) {}

  /**
   * Retrieves paginated transactions for the authenticated user.
   * @param page The page number to retrieve (default is 1).
   * @param limit The maximum number of transactions per page (default is 5).
   */
  getTransactions(page = 1, limit = 5): Observable<any> {
    return this.http.get(
      `http://localhost:5000/api/v1/transactions/?page=${page}&limit=${limit}`,
      { headers: this.authService.getAuthHeaders() }
    );
  }

  /**
   * Retrieves the top-selling items across all supermarkets.
   * @param limit The maximum number of items to retrieve (default is 3).
   */
  getTopSellingItems(limit: number = 3): Observable<any> {
    return this.http.get<any>(
      `http://localhost:5000/api/v1/items/top-selling?limit=${limit}`,
      { headers: this.authService.getAuthHeaders() }
    );
  }
}
