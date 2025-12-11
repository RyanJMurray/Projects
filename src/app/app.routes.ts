import { Routes } from '@angular/router';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { Home } from './components/home/home';
import { Profile } from './components/profile/profile';
import { ItemsDisplay } from './components/items-display/items-display';
import { Basket } from './components/basket/basket';
import { TopSellingChart } from './components/top-selling-chart/top-selling-chart';
import { TestWebService } from './components/test-web-service/test-web-service';

export const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: Login },
    { path: 'register', component: Register },
    { path: 'home', component: Home},
    { path: 'profile', component: Profile},
    { path: 'items/:supermarket_id', component: ItemsDisplay},
    { path: 'basket', component: Basket},
    { path: 'top-selling-chart', component: TopSellingChart},
    { path: 'tests', component: TestWebService}
];
