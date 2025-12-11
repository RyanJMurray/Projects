import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

/**
 * The AuthService manages user authentication, including login, registration,
 * token storage, and retrieval of authentication headers for secure API calls.
 */
@Injectable({
  providedIn: 'root',
})
export class AuthService {

  /** The base URL for user-related API endpoints. */
  private apiUrl = 'http://localhost:5000/api/v1/users';

  /**
   * The constructor for the AuthService.
   * @param http Injected HttpClient used for sending HTTP requests to the backend API.
   */
  constructor(private http: HttpClient) {}

  /**
   * Logs in a user by sending their email and password to the backend.
   * @param email The user's email address.
   * @param password The user's password.
   */
  login(email: string, password: string): Observable<any> {
    const formData = new FormData();
    formData.append('email', email);
    formData.append('password', password);
    return this.http.post(`${this.apiUrl}/login`, formData);
  }

  /**
   * Registers a new user by submitting their registration form data to the backend.
   * @param formData The user's registration details.
   */
  register(formData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}`, formData);
  }

  /**
   * Stores a JWT token in local storage after successful authentication.
   * @param jwt The JWT token to store.
   */
  saveJWT(jwt: string): void {
    localStorage.setItem('token', jwt);
  }

  /**
   * Retrieves the JWT token stored in local storage, if available.
   */
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  /**
   * Logs out the user by removing their stored JWT token from local storage.
   */
  logout(): void {
    localStorage.removeItem('token');
  }

  /**
   * Checks whether a user is currently authenticated based on token presence.
   */
  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  /**
   * Returns the HTTP headers containing the user's JWT for authenticated requests.
   * If no token is available, returns an empty header object.
   */
  getAuthHeaders(): HttpHeaders {
    const token = this.getToken();
    return token
      ? new HttpHeaders({ Authorization: `Bearer ${token}` })
      : new HttpHeaders();
  }
}
