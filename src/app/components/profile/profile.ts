import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ProfileService } from '../../services/profile';
import { AuthService } from '../../services/auth';
import { FormsModule } from '@angular/forms';
import { Transactions } from '../../services/transactions';

/**
 * The Profile component allows users to view and manage their account details,
 * profile image, balance, and password. It also provides access to their
 * transaction history and supports editing user information.
 */
@Component({
  selector: 'app-profile',
  imports: [CommonModule, FormsModule],
  templateUrl: './profile.html',
  styleUrl: './profile.css',
})
export class Profile {

  /** The currently logged-in user's data. */
  user: any = null;

  /** Tracks which profile field is being edited. */
  editingField: string | null = null;

  /** The current profile image URL of the user. */
  profileImage: string | null = null;

  /** Defines the editable profile fields and their labels. */
  editableFields = [
    { key: 'name', label: 'Name' },
    { key: 'email', label: 'Email' },
    { key: 'address', label: 'Address' },
  ];

  /** The list of recent transactions for the user. */
  transactions: any[] = [];

  /** The currently selected transaction for detailed viewing. */
  selectedTransaction: any = null;

  /** Controls visibility of the transaction detail modal. */
  showModal = false;

  /** The amount entered by the user to deposit. */
  depositAmount = 0;

  /** A message displayed after a deposit attempt. */
  depositMessage: string | null = null;

  /** Controls visibility of the password change modal. */
  showPasswordModal = false;

  /** The new password entered by the user. */
  newPassword = '';

  /** The confirmation of the new password entered by the user (required by the backend). */
  confirmPassword = '';

  /** A Success or Error message displayed after attempting to change the password. */
  passwordMessage: string | null = null;

  /** Groups items by supermarket for a selected transaction. Allows to differentiate
   * when multiple items are bought across different stores in a single transaction. */
  groupedItems: { [supermarketName: string]: any[] } = {};

  /** Array of available pagination pages for transactions. */
  pagesArray: number[] = [];

  /** The current transaction page. */
  currentPage = 1;

  /** The total number of transaction pages available. */
  totalPages = 1;

  /**
   * The constructor for the Profile component.
   * @param profileService Service responsible for handling profile-related API calls.
   * @param authService Service used for managing authentication and JWT tokens.
   * @param router Used for navigation between pages.
   * @param transactionService Service for retrieving user transaction history.
   */
  constructor(
    private profileService: ProfileService,
    private authService: AuthService,
    private router: Router,
    private transactionService: Transactions
  ) {}

  /**
   * Loads the authenticated user's details and transaction history on load.
   */
  ngOnInit(): void {
    this.profileService.getAuthenticatedUser().subscribe({
      next: (data) => {
        this.user = data.user || data;
        this.profileImage = this.user.profile_image || null;
      },
      error: (err) => console.error('Error fetching user:', err),
    });

    this.loadTransactions();
  }

  /**
   * Loads the user's transaction history with pagination support.
   */
  loadTransactions(): void {
    this.transactionService.getTransactions(this.currentPage, 5).subscribe({
      next: (res: any) => {
        const txList: any[] = Array.isArray(res.transactions) ? res.transactions : [];
        this.transactions = txList.map((tx: any) => ({
          ...tx,
          purchase_date: tx.purchase_date?.replace('+00:00Z', 'Z') || tx.purchase_date,
        }));
        this.totalPages = res.total_pages ?? 1;
        this.currentPage = res.page || 1;
        this.pagesArray = Array.from({ length: this.totalPages }, (_, i) => i + 1);
      },
      error: (err) => console.error('Error loading transactions:', err),
    });
  }

  /**
   * Loads the selected page of transactions.
   */
  goToPage(): void {
    this.loadTransactions();
  }

  /**
   * Opens a detailed view of a selected transaction in a modal.
   * @param transaction The transaction object to display in detail.
   */
  openTransaction(transaction: any): void {
    this.selectedTransaction = transaction;
    this.groupedItems = transaction.items.reduce((groups: any, item: any) => {
      const market = item.supermarket_name || 'Unknown Supermarket';
      groups[market] = groups[market] || [];
      groups[market].push(item);
      return groups;
    }, {});
    this.showModal = true;
  }

  /**
   * Loads the next page of transactions, if available.
   */
  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.loadTransactions();
    }
  }

  /**
   * Loads the previous page of transactions, if available.
   */
  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadTransactions();
    }
  }

  /**
   * Closes the transaction detail modal.
   */
  closeModal(): void {
    this.showModal = false;
  }

  /**
   * Marks a specific field for editing.
   * @param field The name of the field being edited.
   */
  editField(field: string): void {
    this.editingField = field;
  }

  /**
   * Updates a user profile field.
   * @param field The name of the field being saved.
   */
  saveField(field: string): void {
    const update = { [field]: this.user[field] };
    this.profileService.updateUser(update).subscribe({
      next: () => {
        this.editingField = null;
        alert('Profile updated successfully!');
      },
      error: (err) => {
        alert(`Failed to update profile: ${err.error?.error || 'Unknown error'}`);
      },
    });
  }

  /**
   * Handles selection of a new profile image and uploads it to the server.
   * @param event The file input change event.
   */
  onFileSelected(event: any): void {
    const file = event.target.files[0];
    if (!file) return;

    this.profileService.uploadUserImage(file).subscribe({
      next: (res) => {
        this.user.profile_image = res.updated_fields?.profile_image || res.profile_image;
        alert('Profile image updated!');
      },
      error: (err) => {
        console.error('Upload failed:', err);
        alert('Failed to upload image.');
      },
    });
  }

  /**
   * Removes the user's current profile image.
   */
  removeImage(): void {
    if (!confirm('Remove your profile image?')) return;

    this.profileService.removeProfileImage().subscribe({
      next: () => {
        this.user.profile_image = null;
        alert('Profile image removed.');
      },
      error: (err) => {
        console.error(err);
        alert('Failed to remove image.');
      },
    });
  }

  /**
   * Deposits money into the user's balance.
   * Validates input, updates balance, and refreshes profile data.
   */
  depositMoney(): void {
    if (this.depositAmount <= 0) {
      this.depositMessage = 'Please enter a valid amount.';
      return;
    }

    this.profileService.depositMoney(this.depositAmount).subscribe({
      next: (res) => {
        if (res.user && typeof res.user.balance !== 'undefined') {
          this.user.balance = res.user.balance;
        }
        this.depositMessage = 'Deposit successful!';
        this.depositAmount = 0;
        
        // Used to reload the users account details (to display new balance immediately)
        this.profileService.getAuthenticatedUser().subscribe({
          next: (data) => (this.user = data.user || data),
        });
      },
      error: (err) => {
        console.error('Deposit failed:', err);
        this.depositMessage = 'Failed to deposit money.';
      },
    });
  }

  /**
   * Permanently deletes the user's account after confirmation.
   */
  deleteAccount(): void {
    if (!confirm('Are you sure you want to permanently delete your account?')) return;

    this.profileService.deleteAccount().subscribe({
      next: () => {
        alert('Your account has been deleted successfully.');
        this.authService.logout();
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Account deletion failed:', err);
        alert('Failed to delete account. Please try again.');
      },
    });
  }

  /**
   * Opens the modal for changing the user's password.
   */
  openPasswordModal(): void {
    this.showPasswordModal = true;
    this.newPassword = '';
    this.confirmPassword = '';
    this.passwordMessage = null;
  }

  /**
   * Closes the password change modal.
   */
  closePasswordModal(): void {
    this.showPasswordModal = false;
  }

  /**
   * Updates the users password after confirmation.
   * Logs the user out after a successful password update.
   */
  confirmPasswordChange(): void {
    this.profileService.changePassword(this.newPassword, this.confirmPassword).subscribe({
      next: (res) => {
        this.passwordMessage = res.message || 'Password changed successfully.';
        setTimeout(() => {
          this.authService.logout();
          this.router.navigate(['/login']);
        }, 2000);
      },
      error: (err) => {
        this.passwordMessage = err.error?.error || 'Failed to change password.';
      },
    });
  }

  /**
   * Logs the user out and redirects to the login page.
   */
  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  /**
   * Navigates the user to the home page.
   */
  home(): void {
    this.router.navigate(['/home']);
  }
}
