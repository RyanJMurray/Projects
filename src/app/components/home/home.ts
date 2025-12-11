import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Supermarkets } from '../../services/supermarkets';
import { ProfileIcon } from "../profile-icon/profile-icon";
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Transactions } from '../../services/transactions';

/**
 * The Home component is responsible for displaying all available supermarkets (allowing for filtering), 
 * and providing access to user-managed shops. It also allows users to open new supermarkets and navigate 
 * to their profile page other view items page.
 */
@Component({
  selector: 'app-home',
  imports: [CommonModule, ProfileIcon, FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {

  /** The current page number for pagination. */
  currentPage = 1;

  /** The total number of pages returned by the API. */
  totalPages = 1;

  /** An array of page numbers used for pagination (select drop down for faster navigation). */
  pagesArray: number[] = [];

  /** The list of supermarkets currently displayed. */
  supermarkets: any[] = [];

  /** Indicates if data is currently being loaded. */
  loading = true;

  /** Stores any error messages to be displayed to the user. */
  errorMessage = '';

  /** Determines if the "View Top Selling Items" button should be shown (checks if a user has told +1 items). */
  showTopSellingButton = false;

  /** Controls visibility of the modal used for opening new supermarkets. */
  showOpenShopModal = false;

  /** Error or Success message displayed after attempting to open a supermarket. */
  openShopMessage: string | null = null;

  /** Form template with fields required for creating a new supermarket. */
  newSupermarket = { name: '', location: '', contact: '', image: '' };

  /** Toggles between showing all supermarkets and user-managed ones. */
  showMySupermarkets = false;

  /** Tracks which supermarket field is currently being edited. */
  editingField: string | null = null;

  /** Determines if the user owns any supermarkets (determins if the edit button is visible or not) */
  hasSupermarkets = false;

  /** Active filters used to refine supermarket results. */
  filters = {
    name: '',
    location: '',
    sort_field: 'name',
    sort_by: 'asc'
  };

  /**
   * The constructor for the Home component.
   * @param supermarketService Service responsible for supermarket-related API calls.
   * @param transactionService Service used to check availability of top-selling items.
   * @param router Used for navigating to other components.
   */
  constructor(
    private supermarketService: Supermarkets,
    private transactionService: Transactions,
    private router: Router
  ) {}

  /**
   * Pagination and Supermarket data are retrieved on load alongside checks to see what components
   * should be shown to the user or not (top-selling button, edit supermarkets)
   */
  ngOnInit(): void {
    const savedPage = localStorage.getItem('currentSupermarketPage');
    this.currentPage = savedPage ? parseInt(savedPage, 10) : 1;
    this.loadSupermarkets();
    this.checkTopSellingAvailable();
    this.checkUserHasSupermarkets();
  }

  /**
   * Loads a paginated list of supermarkets from the API.
   */
  loadSupermarkets(): void {
    this.loading = true;
    this.supermarketService.getSupermarkets(this.currentPage, this.filters).subscribe({
      next: (res) => {
        this.supermarkets = res.supermarkets || [];
        this.totalPages = res.total_pages || 1;
        this.currentPage = res.page || 1;
        this.pagesArray = Array.from({ length: this.totalPages }, (_, i) => i + 1);
        this.loading = false;
        this.saveCurrentPage();
      },
      error: (err) => {
        console.error('Failed to fetch supermarkets:', err);
        this.errorMessage = 'Failed to load supermarkets.';
        this.loading = false;
      },
    });
  }

  /**
   * Loads a specific page of supermarkets.
   */
  goToPage(): void {
    if (this.showMySupermarkets) {
      this.loadMySupermarkets();
    } else {
      this.loadSupermarkets();
    }
  }

  /**
   * Loads supermarkets managed by the logged-in user.
   */
  loadMySupermarkets(): void {
    this.loading = true;
    this.supermarketService.getMySupermarkets(this.currentPage).subscribe({
      next: (res) => {
        this.supermarkets = res.supermarkets?.map((s: any) => ({
          ...s,
          created_at: s.created_at?.replace('+00:00Z', 'Z'),
        })) || [];
        this.totalPages = res.total_pages || 1;
        this.currentPage = res.current_page || 1
        this.pagesArray = Array.from({ length: this.totalPages }, (_, i) => i + 1);

        // In the event a page becomes invalid after deletion
        if (this.currentPage > this.totalPages) {
          this.currentPage = this.totalPages;
          return this.loadMySupermarkets();
        }
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading my supermarkets:', err);
        this.errorMessage = 'Failed to load your supermarkets.';
        this.loading = false;
      },
    });
  }

  /**
   * Toggles between viewing all supermarkets and the user's supermarkets.
   */
  toggleMySupermarkets(): void {
    this.currentPage = 1;
    if (this.showMySupermarkets) {
      this.loadMySupermarkets();
    } else {
      this.loadSupermarkets();
    }
  }

  /**
   * Marks a specific supermarket field as editable.
   * @param field The name of the field being edited.
   */
  editField(field: string): void {
    this.editingField = field;
  }

  /**
   * Saves updates made to a specific supermarket field.
   * @param supermarket The supermarket object being updated.
   * @param field The name of the field being saved.
   */
  saveField(supermarket: any, field: string): void {
    this.supermarketService.updateSupermarket(supermarket._id, field, supermarket[field]).subscribe({
      next: () => {
        alert('Supermarket updated successfully!');
        this.editingField = null;
      },
      error: (err) => {
        console.error('Update failed:', err);
        alert('Failed to update supermarket.');
      },
    });
  }

  /**
   * Checks to see if the user owns any supermarkets to determine if they can view the edit supermarket button.
   */
  checkUserHasSupermarkets(): void {
    this.supermarketService.getMySupermarkets(1).subscribe({
      next: (res) => {
        this.hasSupermarkets = res.supermarkets && res.supermarkets.length > 0;
      },
      error: () => {
        this.hasSupermarkets = false;
      }
    });
  }

  /**
   * Saves the current page number to local storage.
   */
  saveCurrentPage(): void {
    localStorage.setItem('currentSupermarketPage', this.currentPage.toString());
  }

  /**
   * Loads the next page of supermarkets if available.
   */
  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.saveCurrentPage();
      this.showMySupermarkets ? this.loadMySupermarkets() : this.loadSupermarkets();
    }
  }

  /**
   * Loads the previous page of supermarkets if available.
   */
  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.saveCurrentPage();
      this.showMySupermarkets ? this.loadMySupermarkets() : this.loadSupermarkets();
    }
  }

  /**
   * Navigates to the Items component for a selected supermarket.
   * @param id The unique identifier of the supermarket.
   */
  viewItems(id: string): void {
    this.router.navigate(['/items', id]);
  }

  /**
   * Applies the currently set filters to the supermarket list.
   */
  applyFilters(): void {
    this.currentPage = 1;
    this.loadSupermarkets();
  }

  /**
   * Clears all active filters and reloads the supermarket list.
   */
  clearFilters(): void {
    this.filters = { name: '', location: '', sort_field: 'name', sort_by: 'asc' };
    this.applyFilters();
  }

  /**
   * Toggles visibility of the "Open New Shop" modal.
   */
  toggleOpenShop(): void {
    this.showOpenShopModal = !this.showOpenShopModal;
    this.openShopMessage = null;
  }

  /**
   * Creates a new supermarket using the provided form data.
   */
  openShop(): void {
    const { name, location, contact } = this.newSupermarket;
    if (!name || !location || !contact) {
      this.openShopMessage = 'Please fill in all required fields.';
      return;
    }

    this.supermarketService.createSupermarket(this.newSupermarket).subscribe({
      next: (res) => {
        this.openShopMessage = res.message || 'Supermarket opened successfully!';
        this.newSupermarket = { name: '', location: '', contact: '', image: '' };
        setTimeout(() => {
          this.showOpenShopModal = false;
          this.loadSupermarkets();
        }, 1500);
      },
      error: (err) => {
        console.error('Error opening supermarket:', err);
        this.openShopMessage = err.error?.error || 'Failed to open supermarket.';
      },
    });
  }

  /**
   * Handles file selection for uploading a supermarket image.
   * @param event The file input change event.
   * @param supermarket The supermarket object being updated.
   */
  onSupermarketImageSelected(event: any, supermarket: any): void {
    const file = event.target.files[0];
    if (!file) return;

    this.supermarketService.uploadSupermarketImage(supermarket._id, file).subscribe({
      next: () => {
        alert('Supermarket image updated successfully!');
        supermarket.supermarket_image = URL.createObjectURL(file);
      },
      error: (err) => {
        console.error('Error updating supermarket image:', err);
        alert('Failed to update supermarket image.');
      },
    });
  }

  /**
   * Removes the image associated with a specific supermarket.
   * @param supermarket The supermarket whose image will be removed.
   */
  removeItemImage(supermarket: any): void {
    if (!confirm('Are you sure you want to remove this image?')) return;

    this.supermarketService.removeSupermarketImage(supermarket._id).subscribe({
      next: () => {
        alert('Image removed successfully!');
        supermarket.supermarket_image = null;
      },
      error: (err) => {
        console.error('Failed to remove image:', err);
        alert(err.error?.error || 'Failed to remove image.');
      },
    });
  }

  /**
   * Deletes a supermarket by its ID after confirmation.
   * @param id The unique identifier of the supermarket to delete.
   */
  deleteSupermarket(id: string): void {
    if (!confirm('Are you sure you want to delete this supermarket?')) return;

    this.supermarketService.deleteSupermarket(id).subscribe({
      next: (res) => {
        alert(res.message || 'Supermarket deleted successfully!');
        this.showMySupermarkets ? this.loadMySupermarkets() : this.loadSupermarkets();
      },
      error: (err) => {
        console.error('Failed to delete supermarket:', err);
        alert(err.error?.error || 'Error deleting supermarket.');
      },
    });
  }

  /**
   * Navigates to the Top Selling Items chart page.
   */
  topSellingItems(): void {
    this.router.navigate(['/top-selling-chart']);
  }

  /**
   * Checks whether top-selling items are available for display.
   */
  checkTopSellingAvailable(): void {
    this.transactionService.getTopSellingItems(1).subscribe({
      next: (res: any) => {
        this.showTopSellingButton = Array.isArray(res?.results) && res.results.length > 0;
      },
      error: (err) => {
        if (err.error?.message === 'No sales found for your supermarkets') {
          this.showTopSellingButton = false;
        } else {
          console.error('Unexpected error:', err);
        }
      }
    });
  }
}
