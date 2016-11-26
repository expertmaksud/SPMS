(function () {
    'use strict';

    angular
        .module('inventory')
        .config(configure);

    configure.$inject = ['$stateProvider', '$urlRouterProvider'];

    function configure($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
        $stateProvider
            .state('stockReceive', {
                url: '/stock/openpurchases',
                templateUrl: '/App/Inventory/views/stocks/purchases.cshtml',
                menu: 'StockReceive'
            })
            .state('addStock', {
                url: '/stock/add/:id',
                templateUrl: '/App/Inventory/views/stocks/addStock.cshtml',
                menu: 'AddStock',
                data: {
                    action: "add"
                }
            })
            .state('stockDetails', {
                url: '/stock/details/:id',
                templateUrl: '/App/Inventory/views/stocks/stockDetails.cshtml',
                menu: 'StockDetails',
                data: {
                    action: "details"
                }
            })


    }

})();