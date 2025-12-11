import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth';

/**
 * The ProfileService handles all operations related to user accounts,
 * including profile updates, deposits, password changes, and deletion.
 */
@Injectable({
  providedIn: 'root',
})
export class ProfileService {

  /** The base URL for all user-related API requests. */
  private baseUrl = 'http://localhost:5000/api/v1/users';

  /**
   * The constructor for the ProfileService.
   * @param http Used to send HTTP requests to the backend API.
   * @param authService Provides JWT headers for authenticated requests.
   */
  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) {}

  /**
   * Retrieves the logged-in users information.
   */
  getAuthenticatedUser(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/auth`, {
      headers: this.authService.getAuthHeaders(),
    });
  }

  /**
   * Updates one or more user profile fields.
   * Automatically handles both text and file uploads.
   * @param data An object containing key-value pairs to update.
   */
  updateUser(data: any): Observable<any> {
    const formData = new FormData();
    for (const key in data) {
      if (data[key] !== undefined && data[key] !== null) {
        formData.append(key, data[key]);
      }
    }

    return this.http.put(`${this.baseUrl}/`, formData, {
      headers: this.authService.getAuthHeaders(),
    });
  }

  /**
   * Uploads a new profile image for the authenticated user.
   * @param file The image file to upload.
   */
  uploadUserImage(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('profile_image', file);

    return this.http.put(`${this.baseUrl}/`, formData, {
      headers: this.authService.getAuthHeaders(),
    });
  }

  /**
   * Removes the user's current profile image by setting it to null.
   */
  removeProfileImage(): Observable<any> {
    return this.http.put(
      `${this.baseUrl}/`,
      { profile_image: null },
      { headers: this.authService.getAuthHeaders() }
    );
  }

  /**
   * Adds money to the user's account balance.
   * @param amount The amount of money to deposit.
   */
  depositMoney(amount: number): Observable<any> {
    const formData = new FormData();
    formData.append('amount', amount.toString());

    return this.http.patch(`${this.baseUrl}/deposit`, formData, {
      headers: this.authService.getAuthHeaders(),
    });
  }

  /**
   * Permanently deletes the user's account.
   */
  deleteAccount(): Observable<any> {
    return this.http.delete(`${this.baseUrl}/`, {
      headers: this.authService.getAuthHeaders(),
    });
  }

  /**
   * Changes the user's password by submitting the new and confirmation values.
   * @param newPassword The user's new password.
   * @param confirmPassword The confirmation of the new password.
   */
  changePassword(newPassword: string, confirmPassword: string): Observable<any> {
    const formData = new FormData();
    formData.append('new_password', newPassword);
    formData.append('re-type new_password', confirmPassword);

    return this.http.patch(`${this.baseUrl}/change_password`, formData, {
      headers: this.authService.getAuthHeaders(),
    });
  }
}
