import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product: IProduct;
  quantity = 1;

  constructor(
    private shopService: ShopService,
    private basketService: BasketService,
    private route: ActivatedRoute,
    private breadcrumb: BreadcrumbService) {
    this.breadcrumb.set('@productDetails', '');
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product, this.quantity);
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  ngOnInit() {
    this.loadProduct();
  }

  loadProduct() {
    this.shopService.getProduct(+this.route.snapshot.paramMap.get('id'))
      .subscribe(product => {
        this.product = product;
        this.breadcrumb.set('@productDetails', this.product.name);
      }, error => {
        console.log(error);
      });
  }

}
