import { NgModule } from '@angular/core';
import { ShopComponent } from './shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: ShopComponent,
  },
  {
    path: ':id',
    component: ProductDetailsComponent,
    data: {
      breadcrumb: {
        alias: 'productDetails'
      }
    }
  }
];

@NgModule({
  declarations: [],
  imports: [
    /*
      we want our routes to be loaded for child
      and that means our routes are not available in app.module
      and they're only going to be available in shop module.
    */
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ShopRoutingModule { }
