import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

/**
 * The Login component handles user authentication by allowing users
 * to enter their credentials and access the application.
 * It also provides navigation to the registration page.
 */
@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {

  /** The user's email address entered in the login form. */
  email = '';

  /** The user's password entered in the login form. */
  password = '';

  /** Stores any error message returned from the login attempt. */
  errorMessage = '';

  /**
   * The constructor for the Login component.
   * @param authService Injected service used for handling authentication requests.
   * @param router Used for navigation after a successful login or to other routes.
   */
  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  /**
   * Clears any existing authentication token from local storage.
   */
  ngOnInit(): void {
    localStorage.removeItem('token');
  }

  /**
   * Handles user login by sending credentials to the authentication service.
   * On success, saves the JWT token and navigates to the home page.
   * On failure, displays an appropriate error message.
   */
  onLogin(): void {
    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        localStorage.setItem('user_id', response.user_id);
        this.authService.saveJWT(response.token);
        this.router.navigate(['/home']);
      },
      error: (err) => {
        this.errorMessage = err.error?.error || 'Invalid Login Credentials';
      }
    });
  }

  /**
   * Navigates the user to the registration page.
   */
  goToRegister(): void {
    this.router.navigate(['/register']);
  }
}