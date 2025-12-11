import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

/**
 * The Users service handles user registration by communicating
 * directly with the backend API.
 */
@Injectable({
  providedIn: 'root',
})
export class Registration {

  /**
   * The constructor for the Users service.
   * @param http Used to perform HTTP requests to the backend API.
   */
  constructor(private http: HttpClient) {}

  /**
   * Registers a new user with the provided account details.
   * Converts the user data into a FormData object for submission.
   * @param data An object containing the user's name, email, password, and address.
   */
  registerUser(data: any): Observable<any> {
    const formData = new FormData();
    for (const key in data) {
      if (data[key] !== undefined) {
        formData.append(key, data[key]);
      }
    }

    return this.http.post(`http://localhost:5000/api/v1/users`, formData);
  }
}
