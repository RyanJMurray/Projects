import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Registration } from '../../services/registration';

/**
 * The Register component allows new users to create an account
 * by providing their name, email, password, and address.
 */
@Component({
  selector: 'app-register',
  imports: [FormsModule, CommonModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {

  /** The user's full name entered during registration. */
  name = '';

  /** The user's email address entered during registration. */
  email = '';

  /** The user's chosen password for account creation. */
  password = '';

  /** The user's address entered during registration. */
  address = '';

  /** A message displayed when registration succeeds. */
  successMessage: string | null = null;

  /** A message displayed when registration fails. */
  errorMessage: string | null = null;

  /**
   * The constructor for the Register component.
   * @param registrationService Service responsible for handling user registration.
   * @param router Used to navigate to the login page upon successful registration.
   */
  constructor(
    private registrationService: Registration,
    private router: Router
  ) {}

  /**
   * Submits the registration form and creates a new user account.
   * On success, displays a confirmation message and redirects to the login page.
   */
  onRegister(): void {
    const userData = {
      name: this.name,
      email: this.email,
      password: this.password,
      address: this.address,
    };

    this.registrationService.registerUser(userData).subscribe({
      next: () => {
        this.successMessage = 'Registration successful! Redirecting...';
        this.errorMessage = null;

        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 2000);
      },
      error: (err) => {
        console.error('Registration failed:', err);
        this.successMessage = null;
        this.errorMessage =
          err.error?.error || 'Registration failed. Please try again.';
      },
    });
  }
  
  /** Returns the user to the Login page. */
  goToLogin(): void {
    this.router.navigate(['/login']);
  }
}