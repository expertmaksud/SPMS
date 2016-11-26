(function () {
    'use strict';

    angular
        .module('procurement')
        .config(configure);

    configure.$inject = ['$stateProvider', '$urlRouterProvider'];

    function configure($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
        $stateProvider
            .state('createPurchase', {
                url: '/purchase/new',
                templateUrl: '/App/Procurement/views/purchases/purchases.cshtml',
                menu: 'CreatePurchase'
            })
             .state('purchaseList', {
                 url: '/purchase/list',
                 templateUrl: '/App/Procurement/views/purchases/purchaseList.cshtml',
                 menu: 'PurchaseList'
             })
            .state('editPurchase', {
                url: '/purchase/edit/:id',
                templateUrl: '/App/Procurement/views/purchases/editPurchase.cshtml',
                menu: 'EditPurchase',
                data: {
                    action: "edit"
                }
            })
         .state('purchaseDetails', {
             url: '/purchase/detail/:id',
             templateUrl: '/App/Procurement/views/purchases/purchaseDetail.cshtml',
             menu: 'PurchaseDetail',
             data: {
                 action: "detail"
             }
         });


    }

})();