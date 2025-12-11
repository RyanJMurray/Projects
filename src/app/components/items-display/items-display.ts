import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Items } from '../../services/items';
import { BasketService } from '../../services/basket';
import { BasketIcon } from '../basket-icon/basket-icon';
import { ProfileIcon } from '../profile-icon/profile-icon';

/**
 * The ItemsDisplay component is responsible for displaying all items
 * belonging to a specific supermarket. It provides functionality for
 * filtering, pagination, item management, and adding items to the basket.
 */
@Component({
  selector: 'app-items-display',
  imports: [CommonModule, ProfileIcon, BasketIcon, FormsModule],
  templateUrl: './items-display.html',
  styleUrl: './items-display.css',
})
export class ItemsDisplay {

  /** The ID of the supermarket currently being viewed. */
  supermarketId!: string;

  /** The list of items returned from the API. */
  items: any[] = [];

  /** The name of the current supermarket. */
  supermarketName = '';

  /** The location of the current supermarket. */
  location = '';

  /** The current page number for pagination. */
  currentPage = 1;

  /** The total number of available pages. */
  totalPages = 1;

  /** An array of available page numbers for pagination buttons. */
  pagesArray: number[] = [];

  /** The total number of items in the supermarket. */
  totalItems = 0;

  /** Indicates if the data is still being loaded. */
  loading = true;

  /** Stores any error message that occurs during API calls. */
  errorMessage = '';

  /** Determines if the current user is the owner of the supermarket. */
  isOwner = false;

  /** Stores quantities of each item added to the basket. */
  quantities: { [key: string]: number } = {};

  /** Tracks which field of an item is being edited. */
  editingField: string | null = null;

  /** Indicates whether the edit mode is active. */
  editMode = false;

  /** Controls visibility of the create item section. */
  showCreateItem = false;

  /** Controls visibility of the create item modal. */
  showCreateModal = false;

  /** Form data for creating a new item. */
  newItem = {
    name: '',
    price: '',
    stock: '',
    category: '',
    description: ''
  };

  /** Filters used to refine the list of displayed items. */
  filters = {
    name: '',
    category: '',
    min_price: '',
    max_price: '',
    sort_field: 'price',
    sort_by: 'asc'
  };

  /**
   * The constructor for the ItemsDisplay component.
   * @param route Used to retrieve supermarket ID from the route parameters.
   * @param itemsService Injected service for handling item-related API requests.
   * @param router Used for navigating between pages.
   * @param basketService Injected service responsible for managing the shopping basket.
   */
  constructor(
    private route: ActivatedRoute,
    private itemsService: Items,
    private router: Router,
    private basketService: BasketService
  ) {}

  /**
   * Retrieves the supermarket ID from the route and loads items + current page.
   */
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
    this.supermarketId = params.get('supermarket_id')!;
    const savedPage = localStorage.getItem(`items_page_${this.supermarketId}`);
    this.currentPage = savedPage ? parseInt(savedPage, 10) : 1;
    this.loadItems();
   });
  }

  /**
   * Loads items for the current supermarket with applied filters and pagination.
   */
  loadItems(): void {
    this.loading = true;

    const params: any = {
      page: this.currentPage,
      sort_field: this.filters.sort_field,
      sort_by: this.filters.sort_by
    };

    if (this.filters.name) params.name = this.filters.name;
    if (this.filters.category) params.category = this.filters.category;
    if (this.filters.min_price) params.min_price = this.filters.min_price;
    if (this.filters.max_price) params.max_price = this.filters.max_price;

    this.itemsService.getItemsBySupermarket(this.supermarketId, this.currentPage, params)
      .subscribe({
        next: (res) => {
          this.items = res.items || [];
          this.supermarketName = res.supermarket;
          this.location = res.location;
          this.isOwner = res.is_owner || false;
          this.totalPages = res.total_pages || 1;
          this.currentPage = res.page || 1;
          this.pagesArray = Array.from({ length: this.totalPages }, (_, i) => i + 1);
          this.loading = false;
        },
        error: (err) => {
          console.error('Failed to load items:', err);
          this.errorMessage = 'Unable to load items.';
          this.loading = false;
        },
      });
  }

  /**
   * Loads the current page of items.
   */
  goToPage(): void {
    this.loadItems();
  }

  /**
   * Applies active filters and reloads items from the first page.
   */
  applyFilters(): void {
    this.currentPage = 1;
    this.loadItems();
  }

  /**
   * Clears all applied filters and reloads items.
   */
  clearFilters(): void {
    this.filters = {
      name: '',
      category: '',
      min_price: '',
      max_price: '',
      sort_field: 'price',
      sort_by: 'asc'
    };
    this.applyFilters();
  }

  /**
   * Loads the next page of items, if available.
   */
  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.savePage();
      this.loadItems();
    }
  }

  /**
   * Loads the previous page of items, if available.
   */
  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.savePage();
      this.loadItems();
    }
  }

  /**
   * Saves the current page number in local storage.
   */
  savePage(): void {
    localStorage.setItem(`items_page_${this.supermarketId}`, this.currentPage.toString());
  }

  /**
   * Adds an item to the basket with the specified quantity.
   * @param item The item object being added to the basket.
   */
  addToBasket(item: any): void {
    const quantity = this.getQuantity(item);
    this.basketService.addItem({ ...item, quantity });
    alert(`${item.name} (x${quantity}) added to your basket!`);
  }

  /**
   * Increases the selected quantity for an item, up to the stock limit.
   * @param item The item whose quantity is being increased.
   */
  increaseQuantity(item: any): void {
    const current = this.quantities[item._id] || 1;
    if (current < item.stock) this.quantities[item._id] = current + 1;
  }

  /**
   * Decreases the selected quantity for an item, down to a minimum of one.
   * @param item The item whose quantity is being decreased.
   */
  decreaseQuantity(item: any): void {
    const current = this.quantities[item._id] || 1;
    if (current > 1) this.quantities[item._id] = current - 1;
  }

  /**
   * Retrieves the selected quantity for a specific item.
   * @param item The item to get the quantity for.
   */
  getQuantity(item: any): number {
    return this.quantities[item._id] || 1;
  }

  /**
   * Saves the current page and navigates back to the Home component.
   */
  home(): void {
    this.savePage();
    this.router.navigate(['/home']);
  }

  /**
   * Marks a specific field as editable for an item.
   * @param field The field name being edited.
   */
  editField(field: string): void {
    this.editingField = field;
  }

  /**
   * Toggles the edit mode for item management.
   */
  toggleEditMode(): void {
    this.editMode = !this.editMode;
    this.editingField = null;
  }

  /**
   * Updates a specific field regarding an item.
   * @param item The item being updated.
   * @param field The field name being updated.
   */
  saveField(item: any, field: string): void {
    this.itemsService.updateItem(item._id, field, item[field]).subscribe({
      next: () => {
        alert('Item updated successfully!');
        this.editingField = null;
      },
      error: (err) => {
        console.error('Update failed:', err);
        alert('Failed to update item.');
      },
    });
  }

  /**
   * Handles file selection for uploading an item image.
   * @param event The file input event.
   * @param item The item associated with the image upload.
   */
  onItemImageSelected(event: any, item: any): void {
    const file = event.target.files[0];
    if (!file) return;

    this.itemsService.uploadItemImage(item._id, file).subscribe({
      next: (res) => {
        item.image_url = res.image_url || item.image_url;
        alert('Item image updated successfully!');
      },
      error: (err) => console.error('Image upload failed:', err),
    });
  }

  /**
   * Removes the image associated with an item.
   * @param item The item whose image will be removed.
   */
  removeItemImage(item: any): void {
    if (!confirm('Are you sure you want to remove this image?')) return;

    this.itemsService.removeItemImage(item._id).subscribe({
      next: () => {
        item.image_url = null;
        alert('Image removed successfully!');
      },
      error: (err) => {
        console.error('Failed to remove image:', err);
        alert(err.error?.error || 'Failed to remove image.');
      },
    });
  }

  /**
   * Deletes an item after user confirmation.
   * @param itemId The unique identifier of the item to delete.
   */
  deleteItem(itemId: string): void {
    if (!confirm('Are you sure you want to delete this item?')) return;

    this.itemsService.deleteItem(itemId).subscribe({
      next: () => {
        alert('Item deleted successfully!');
        this.loadItems();
      },
      error: (err) => console.error('Delete failed:', err),
    });
  }

  /**
   * Toggles the visibility of the "Create Item" section.
   */
  toggleCreateItem(): void {
    this.showCreateItem = !this.showCreateItem;
  }

  /**
   * Creates a new item using the form data.
   */
  createItem(): void {
    if (!this.newItem.name || !this.newItem.price || !this.newItem.stock) {
      alert('Please fill in all required fields before submitting.');
      return;
    }

    this.itemsService.createItem(this.supermarketId, this.newItem).subscribe({
      next: () => {
        alert('Item created successfully!');
        this.showCreateModal = false;
        this.newItem = { name: '', price: '', stock: '', category: '', description: '' };
        this.loadItems();
      },
      error: (err) => {
        console.error('Item creation failed:', err);
        alert(err.error?.error || 'Failed to create item.');
      },
    });
  }

  /**
   * Opens the modal for creating a new item.
   */
  openCreateModal(): void {
    this.showCreateModal = true;
  }

  /**
   * Closes the create item modal.
   */
  closeCreateModal(): void {
    this.showCreateModal = false;
  }
}
