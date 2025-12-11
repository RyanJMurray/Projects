import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ProfileService } from '../../services/profile';
import { AuthService } from '../../services/auth';

/**
 * The ProfileIcon component displays the logged-in user's profile image or initials
 * in the top corner of the home/item-display screen. It provides quick access to the user's profile page.
 */
@Component({
  selector: 'app-profile-icon',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './profile-icon.html',
  styleUrl: './profile-icon.css',
})
export class ProfileIcon {

  /** The user's profile image URL (if available). */
  profileImage: string | null = null;

  /** The user's initials displayed when no profile image is available. */
  initials = '?';

  /**
   * The constructor for the ProfileIcon component.
   * @param profileService Service responsible for retrieving user profile data.
   * @param authService Service used for authentication and managing tokens.
   * @param router Used for navigation between routes.
   */
  constructor(
    private profileService: ProfileService,
    private authService: AuthService,
    private router: Router
  ) {}

  /**
   * Fetches the authenticated user's details and sets the profile image or initials.
   */
  ngOnInit(): void {
    this.profileService.getAuthenticatedUser().subscribe({
      next: (data) => {
        const user = data.user || data;
        if (!user) return;

        // Set profile image if available
        if (user.profile_image) {
          this.profileImage = user.profile_image;
        }

        // Generate initials from user name if no image
        const name = user?.name?.trim();
        if (name) {
          const parts = name.split(' ');
          this.initials = parts
            .map((part: string) => part.charAt(0).toUpperCase())
            .join('');
        }
      },
      error: (err) => console.error('Error fetching user:', err),
    });
  }

  /**
   * Navigates the user to their profile page when the icon is clicked.
   */
  goToProfile(): void {
    this.router.navigate(['/profile']);
  }
}
