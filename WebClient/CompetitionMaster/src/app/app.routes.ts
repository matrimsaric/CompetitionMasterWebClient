import { Routes } from '@angular/router';


import { SingleUserComponent } from './user/single-user/single-user.component';
import { IndexComponent } from './index/index.component';

export const routes: Routes = [
    { path: 'index', component: IndexComponent},
    { path: 'single-user/:id', component: SingleUserComponent },
    { path: '',redirectTo:'index', pathMatch:'full'},
    { path: '**', component: IndexComponent}
];


