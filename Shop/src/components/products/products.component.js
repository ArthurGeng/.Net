function Products(productService) {
    const ctrl = this;
    ctrl.productsArray = [];
    ctrl.tempProduct = null;

    productService.loadProducts()
        .then(function (res) {
            ctrl.productsArray = res;
        }, function () { });

    ctrl.productDetails = function () {
        productService.loadProductDetails()
            .then(function (res) {
                ctrl.tempProduct = res[0];
                this.tempProduct = res[0];
                console.log(res[0]);
            }, function () { });
    };
};

app.component("products", {
    templateUrl: "/src/components/products/products.component.html",
    controller: Products
});