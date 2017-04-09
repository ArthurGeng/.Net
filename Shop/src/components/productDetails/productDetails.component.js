function ProductDetails(productService) {
    var ctrl = this;

    productService.loadProductDetails().
        then(function (res) {
            ctrl.productDateails = res[0];
        }, function (res) {

        });
}

app.component("productDetails", {
    templateUrl: "/src/components/productDetails/productDetails.component.html",
    controller: ProductDetails,
});