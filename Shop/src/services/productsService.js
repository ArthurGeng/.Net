app.service("productService", function ($http, $q) {

    this.loadProducts = function () {
        const deffered = $q.defer();
        $http.get('/api/Products')
            .then(function (res) {
                deffered.resolve(res.data);
            }, function (err) {
                deffered.reject(err);
            });
        return deffered.promise;
    };

    this.loadProductDetails = function () {
        const deffered = $q.defer();
        $http.get('/api/ProductDetails')
            .then(function (res) {
                deffered.resolve(res.data);
            }, function (err) {
                deffered.reject(err);
            });
        return deffered.promise;
    }
});