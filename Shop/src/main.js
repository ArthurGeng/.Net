const app = angular.module("mainApp", ['ngRoute'])
    .config(['$routeProvider',
        function config($routeProvider) {

            $routeProvider.
                when('/ProductDetails', {
                    template: '<product-details></product-details>'

                }).
                otherwise({ template: '<app></app>' });


        }]);

