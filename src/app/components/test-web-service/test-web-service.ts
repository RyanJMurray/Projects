import { Component } from '@angular/core';
import { Supermarkets } from '../../services/supermarkets';
import { Items } from '../../services/items';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth';
import { Registration } from '../../services/registration';
import { ProfileService } from '../../services/profile';
import { Transactions } from '../../services/transactions';
@Component({
  selector: 'app-test-web-service',
  standalone: true,
  templateUrl: './test-web-service.html',
  styleUrl: './test-web-service.css',
  providers: [Supermarkets, Items],
  imports: [CommonModule]
})
export class TestWebService {

  test_output: string[] = [];
  first_page: any[] = [];
  second_page: any[] = [];

  constructor(private supermarketsService: Supermarkets, private itemsService: Items, private authService: AuthService, private registrationService: Registration, private profileService: ProfileService, private transactionsService: Transactions) {}

  ngOnInit() {
    this.loginUser('ryan_automated1@gmail.com', 'test123@');

    setTimeout(() => {
      this.SupermarketTests();
    }, 1000);

    setTimeout(() => {
      this.ItemsTests();
    }, 4000);

    setTimeout(() => {
      this.TransactionsTests();
    }, 7000);

     setTimeout(() => {
      this.UsersTests();
    }, 10000);
  }

  private SupermarketTests() {
    this.test_output.push('\nSUPERMARKET TESTS --------------------');
    this.testCreateUpdateDeleteSupermarket();
    this.testSupermarketsFetched();
    this.testPaginationDifferent();
    this.testFilterSupermarketByName();
    this.testFilterByLocation();
    this.testSortingOrder();
  }

  private ItemsTests(){
    this.test_output.push('\nITEMS TESTS --------------------');
    this.testCreateUpdateDeleteItem();
    this.testItemsFetchBySupermarket();
    this.testFilterItemsByName();
    this.testFilterItemsByCategory();
    this.testSortItemsByPrice();
  }

  private UsersTests() {
    this.test_output.push('\nUSER TESTS --------------------');
    this.testCreateUser();
  }

  private TransactionsTests() {
    this.test_output.push('\nTRANSACTION TESTS --------------------');
    this.testGetTransactions();
    this.testGetTopSellingItems();
  }

  private loginUser(email: string, password: string) {
    this.authService.login(email, password).subscribe({
      next: (res: any) => {
        if (res?.token) {
          this.authService.saveJWT(res.token);
          this.test_output.push('Logged in successfully');
        } else {
          this.test_output.push('Login failed: No token returned');
        }
      },
      error: (err) => {
        this.test_output.push('Login failed: ' + err.message);
      }
    });
  }

  private testSupermarketsFetched() {
    this.supermarketsService.getSupermarkets(1, {}).subscribe({
      next: (res) => {
        const list = res.supermarkets || [];
        if (Array.isArray(list) && list.length > 0)
          this.test_output.push('1st Page of supermarkets fetched: PASSED!');
        else
          this.test_output.push('1st Page of supermarkets fetched: FAILED!');
      },
      error: (err) => {
        this.test_output.push('Page of supermarkets fetched: ERROR ' + err.message);
      }
    });
  }

  private testPaginationDifferent() {
    this.supermarketsService.getSupermarkets(1, {}).subscribe({
      next: (res1) => {
        this.first_page = res1.supermarkets || [];
        this.supermarketsService.getSupermarkets(2, {}).subscribe({
          next: (res2) => {
            this.second_page = res2.supermarkets || [];
            if (
              this.first_page.length > 0 &&
              this.second_page.length > 0 &&
              this.first_page[0]._id !== this.second_page[0]._id
            )
              this.test_output.push('Pagination returns different data: PASSED!');
            else
              this.test_output.push('Pagination returns different data: FAILED!');
          },
          error: (err) => this.test_output.push('Pagination test: ERROR ' + err.message)
        });
      }
    });
  }

  private testItemsFetchBySupermarket() {
    this.supermarketsService.getSupermarkets(1, {}).subscribe({
      next: (res) => {
        const firstMarket = res.supermarkets?.[0];
        if (!firstMarket?._id) {
          this.test_output.push('Fetch items by supermarket: FAILED (no supermarkets)');
          return;
        }

        this.itemsService.getItemsBySupermarket("68e94f4c92d48af6ba91264b", 1, {}).subscribe({
          next: (res2) => {
            if (Array.isArray(res2.items))
              this.test_output.push('Fetch items by supermarket: PASSED!');
            else
              this.test_output.push('Fetch items by supermarket: FAILED!');
          },
          error: (err) =>
            this.test_output.push('Fetch items by supermarket: ERROR ' + err.message)
        });
      },
      error: (err) => {
        this.test_output.push('Fetch items by supermarket: ERROR ' + err.message);
      }
    });
  }

  private testFilterSupermarketByName() {
    this.supermarketsService.getSupermarkets(1, { name: 'Aldi' }).subscribe({
      next: (res) => {
        const matches = res.supermarkets.every((s: any) =>
          s.name.toLowerCase().includes('aldi')
        );
        if (matches && res.supermarkets.length > 0)
          this.test_output.push('Filter by name (Aldi): PASSED!');
        else
          this.test_output.push('Filter by name (Aldi): FAILED!');
      },
      error: (err) => this.test_output.push('Filter by name: ERROR ' + err.message)
    });
  }

  private testFilterByLocation() {
    this.supermarketsService.getSupermarkets(1, { location: 'Belfast' }).subscribe({
      next: (res) => {
        const matches = res.supermarkets.every((s: any) =>
          s.location.includes('Belfast')
        );
        if (matches && res.supermarkets.length > 0)
          this.test_output.push('Filter by location (Belfast): PASSED!');
        else
          this.test_output.push('Filter by location (Belfast): FAILED!');
      },
      error: (err) => this.test_output.push('Filter by location (Belfast): ERROR ' + err.message)
    });
  }

  private testSortingOrder() {
    this.supermarketsService.getSupermarkets(1, { sort_field: 'name', sort_by: 'asc' }).subscribe({
      next: (ascRes) => {
        const ascNames = ascRes.supermarkets.map((s: any) => s.name);
        this.supermarketsService.getSupermarkets(1, { sort_field: 'name', sort_by: 'desc' }).subscribe({
          next: (descRes) => {
            const descNames = descRes.supermarkets.map((s: any) => s.name);
            if (ascNames[0] !== descNames[0])
              this.test_output.push('Sorting by name asc/desc: PASSED!');
            else
              this.test_output.push('Sorting by name asc/desc: FAILED!');
          },
          error: (err) => this.test_output.push('Sort DESC test: ERROR ' + err.message)
        });
      },
      error: (err) => this.test_output.push('Sort ASC test: ERROR ' + err.message)
    });
  }

  private testCreateUpdateDeleteSupermarket() {
    const newSupermarket = { name: 'Test Shop', location: 'Test Location', contact: '12345678109' };

    this.supermarketsService.createSupermarket(newSupermarket).subscribe({
      next: (createRes: any) => {
        if (createRes && createRes.supermarket && createRes.supermarket._id) {
          this.test_output.push('Create supermarket: PASSED!');
          const supermarketId = createRes.supermarket._id;

          const updateData = new FormData();
          updateData.append('location', 'UpdatedVille');

          this.supermarketsService.updateSupermarket(supermarketId, 'location', 'UpdatedVille').subscribe({
            next: (updateRes: any) => {
              if (updateRes && updateRes.message?.includes('updated')) {
                this.test_output.push('Update supermarket: PASSED!');
              } else {
                this.test_output.push('Update supermarket: FAILED!');
              }

              this.supermarketsService.deleteSupermarket(supermarketId).subscribe({
                next: (deleteRes: any) => {
                  if (deleteRes && deleteRes.message?.includes('Supermarket has been closed down')) {
                    this.test_output.push('Delete supermarket: PASSED!');
                  } else {
                    this.test_output.push('Delete supermarket: FAILED!');
                  }
                },
                error: (err) => {
                  console.error('Delete error:', err);
                  this.test_output.push('Delete supermarket: ERROR ' + err.message);
                },
              });
            },
            error: (err) => {
              console.error('Update error:', err);
              this.test_output.push('Update supermarket: ERROR ' + err.message);
            },
          });
        } else {
          this.test_output.push('Create supermarket: FAIL (no ID returned)');
        }
      },
      error: (err) => {
        console.error('Create error:', err);
        this.test_output.push('Create supermarket: ERROR ' + err.message);
      },
    });
  }

  private testCreateUpdateDeleteItem() {
    const supermarketId = "68e94f4c92d48af6ba91264b"; 

    this.itemsService.createItem(supermarketId, {
        name: 'Test Item',
        price: '10.99',
        stock: '20',
        category: 'Snacks',
        description: 'Crunchy test item'
      }).subscribe({
        next: (createRes: any) => {
          if (createRes?.item?._id) {
            this.test_output.push('Create item: PASSED!');
            const itemId = createRes.item._id;

            this.itemsService.updateItem(itemId, 'price', '12.49').subscribe({
              next: (updateRes: any) => {
                if (updateRes?.message?.includes('updated')) {
                  this.test_output.push('Update item: PASSED!');
                } else {
                  this.test_output.push('Update item: FAILED!');
                }

                this.itemsService.deleteItem(itemId).subscribe({
                  next: (deleteRes: any) => {
                    if (deleteRes?.message?.includes('Item deleted successfully')) {
                      this.test_output.push('Delete item: PASSED!');
                    } else {
                      this.test_output.push('Delete item: FAILED!');
                    }
                  },
                  error: (err) => {
                    console.error('Delete error:', err);
                    this.test_output.push('Delete item: ERROR ' + err.message);
                  }
                });
              },
              error: (err) => {
                console.error('Update error:', err);
                this.test_output.push('Update item: ERROR ' + err.message);
              }
            });
          } else {
            this.test_output.push('Create item: FAILED! (no ID returned)');
          }
        },
        error: (err) => {
          console.error('Create error:', err);
          this.test_output.push('Create item: ERROR ' + err.message);
        }
      });
    }

  private testFilterItemsByName() {
    this.itemsService.getItemsBySupermarket("68fd033c6b0278f63148bcdf", 1, { name: 'Ruler' }).subscribe({
      next: (res) => {
        const matches = res.items.every((i: any) =>
          i.name.includes('Ruler')
        );
        if (matches && res.items.length > 0)
          this.test_output.push('Filter items by name (Ruler): PASSED!');
        else
          this.test_output.push('Filter items by name (Ruler): FAILED!');
      },
      error: (err) => this.test_output.push('Filter items by name: ERROR ' + err.message)
    });
  }

  private testFilterItemsByCategory() {
    this.itemsService.getItemsBySupermarket("68fd033c6b0278f63148bcdf", 1, { category: 'Bakery' }).subscribe({
      next: (res) => {
        const matches = res.items.every((i: any) =>
          i.category.includes('Bakery')
        );
        if (matches && res.items.length > 0)
          this.test_output.push('Filter items by category (Bakery): PASSED!');
        else
          this.test_output.push('Filter items by category (Bakery): FAILED!');
      },
      error: (err) => this.test_output.push('Filter items by category: ERROR ' + err.message)
    });
  }

  private testSortItemsByPrice() {
    const supermarketId = "68fd033c6b0278f63148bcdf";

    this.itemsService.getItemsBySupermarket(supermarketId, 1, { sort_field: 'price', sort_by: 'asc' }).subscribe({
      next: (ascRes) => {
        const ascPrices = ascRes.items.map((i: any) => i.price);
        this.itemsService.getItemsBySupermarket(supermarketId, 1, { sort_field: 'price', sort_by: 'desc' }).subscribe({
          next: (descRes) => {
            const descPrices = descRes.items.map((i: any) => i.price);
            if (ascPrices[0] !== descPrices[0])
              this.test_output.push('Sorting by price asc/desc: PASSED!');
            else
              this.test_output.push('Sorting by price asc/desc: FAILED!');
          },
          error: (err) => this.test_output.push('Sort DESC test: ERROR ' + err.message)
        });
      },
      error: (err) => this.test_output.push('Sort ASC test: ERROR ' + err.message)
    });
  }

private tempEmail = 'test_email@gmail.com';
private tempPassword = 'StrongPass123!';

private testCreateUser() {
  const newUser = {
    name: 'Temp Tester',
    email: this.tempEmail,
    password: this.tempPassword,
    address: '123 Test Lane',
  };

  this.registrationService.registerUser(newUser).subscribe({
    next: (res: any) => {
      if (res?.user?._id) {
        this.test_output.push('Create user: PASSED!');
        this.testLoginUser();
      } else {
        this.test_output.push('Create user: FAILED (no ID returned)');
      }
    },
    error: (err) => this.test_output.push('Create user: ERROR ' + err.message),
  });
}

  private testLoginUser() {
    this.authService.login(this.tempEmail, this.tempPassword).subscribe({
      next: (res: any) => {
        if (res?.token) {
          this.test_output.push('Login user: PASSED!');
          this.authService.saveJWT(res.token);
          this.testUpdateUser();
        } else {
          this.test_output.push('Login user: FAILED (no token)');
        }
      },
      error: (err) => this.test_output.push('Login user: ERROR ' + err.message),
    });
  }

  private testUpdateUser() {
    this.profileService.updateUser({ address: 'Updated Test Lane' }).subscribe({
      next: (res: any) => {
        if (res?.message?.includes('updated')) {
          this.test_output.push('Update user: PASSED!');
        } else {
          this.test_output.push('Update user: FAILED!');
        }
        this.testDepositUser();
      },
      error: (err) => this.test_output.push('Update user: ERROR ' + err.message),
    });
  }

  private testDepositUser() {
    this.profileService.depositMoney(10).subscribe({
      next: (res: any) => {
        if (res?.balance || res?.user?.balance) {
          this.test_output.push('Deposit money: PASSED!');
        } else {
          this.test_output.push('Deposit money: FAILED!');
        }
        this.testChangePassword();
      },
      error: (err) =>
        this.test_output.push('Deposit money: ERROR ' + err.message),
    });
  }

  private testChangePassword() {
    this.profileService.changePassword('NewPass123!', 'NewPass123!').subscribe({
      next: (res: any) => {
        if (res?.message?.includes('Password change successful')) {
          this.test_output.push('Change password: PASSED!');
        } else {
          this.test_output.push('Change password: FAILED!');
        }
        this.testDeleteUser();
      },
      error: (err) =>
        this.test_output.push('Change password: ERROR ' + err.message),
    });
  }

  private testDeleteUser() {
    this.profileService.deleteAccount().subscribe({
      next: (res: any) => {
        if (res?.message?.includes('deleted')) {
          this.test_output.push('Delete user: PASSED!');
        } else {
          this.test_output.push('Delete user: FAILED!');
        }
        this.authService.logout();
        this.test_output.push('Logout user: PASSED!');
      },
      error: (err) =>
        this.test_output.push('Delete user: ERROR ' + err.message),
    });
  }

  private testGetTransactions() {
    this.transactionsService.getTransactions().subscribe({
      next: (res: any) => {
        if (res?.transactions && Array.isArray(res.transactions) && res.transactions.length >= 0) {
          this.test_output.push('Get transactions: PASSED!');
        } else {
          this.test_output.push('Get transactions: FAILED!');
        }
      },
      error: (err) => {
        this.test_output.push('Get transactions: ERROR ' + err.message);
      }
    });
  }

  private testGetTopSellingItems() {
    this.transactionsService.getTopSellingItems().subscribe({
      next: (res: any) => {
        if (res?.results && Array.isArray(res.results) && res.results.length >= 0) {
          this.test_output.push('Get top-selling items: PASSED!');
        } else {
          this.test_output.push('Get top-selling items: FAILED!');
        }
      },
      error: (err) => {
        this.test_output.push('Get top-selling items: ERROR ' + err.message);
      }
    });
  }

}
