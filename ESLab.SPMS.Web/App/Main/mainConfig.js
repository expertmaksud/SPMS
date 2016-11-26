(function () {
    'use strict';

    angular
        .module('main')
        .config(configure);

    configure.$inject = ['$stateProvider', '$urlRouterProvider'];


    function configure($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/App/Main/views/home/home.cshtml',
                menu: 'Home' //Matches to name of 'Home' menu in SPMSNavigationProvider
            })
            .state('freights', {
                url: '/freights',
                templateUrl: '/App/Main/views/settings/freights/freights.cshtml',
                menu: 'Freights'
            })
            .state('brands', {
                url: '/brands',
                templateUrl: '/App/Main/views/settings/brands/brands.cshtml',
                menu: 'Brands'
            })
            .state('zones', {
                url: '/zones',
                templateUrl: '/App/Main/views/settings/zones/Zones.cshtml',
                menu: 'Zones'
            })
            .state('productGrades', {
                url: '/productGrades',
                templateUrl: '/App/Main/views/settings/productGrades/ProductGrades.cshtml',
                menu: 'ProductGrades'
            })
            .state('productCategories', {
                url: '/productCategories',
                templateUrl: '/App/Main/views/settings/productcategories/ProductCategories.cshtml',
                menu: 'ProductCategories'
            })
            .state('vendors', {
                url: '/vendors',
                templateUrl: '/App/Main/views/settings/vendors/vendors.cshtml',
                menu: 'Vendors'
            })
            .state('productUnits', {
                url: '/ProductUnits',
                templateUrl: '/App/Main/views/settings/productunits/ProductUnits.cshtml',
                menu: 'ProductUnits'
            })
            .state('rawMaterialTypes', {
                url: '/RawMaterialTypes',
                templateUrl: '/App/Main/views/settings/rawmaterialtypes/RawMaterialTypes.cshtml',
                menu: 'RawMaterialTypes'
            })
            .state('productApis', {
                url: '/ProductApis',
                templateUrl: '/App/Main/views/settings/productapis/ProductApis.cshtml',
                menu: 'ProductApis'
            })
            .state('distributors', {
                url: '/Distributors',
                templateUrl: '/App/Main/views/settings/distributors/Distributors.cshtml',
                menu: 'Distributors'
            })
            .state('rawMaterials', {
                url: '/RawMaterials',
                templateUrl: '/App/Main/views/settings/rawmaterials/RawMaterials.cshtml',
                menu: 'RawMaterials'
            })
            .state('finishProducts', {
                url: '/FinishProducts',
                templateUrl: '/App/Main/views/settings/finishproducts/FinishProductWithFormula.cshtml',
                menu: 'FinishProducts'
            })
            .state('finishProductList', {
                url: '/FinishProductList',
                templateUrl: '/App/Main/views/settings/finishproducts/finishProductList.cshtml',
                menu: 'FinishProductList'
            })
            .state('warehouses', {
                url: '/Warehouses',
                templateUrl: '/App/Main/views/settings/warehouses/Warehouses.cshtml',
                menu: 'Warehouses'
            })
            .state('finishProductDetails', {
                url: '/finishproduct/detail/:id',
                templateUrl: '/App/Main/views/settings/finishproducts/finishProductDetails.cshtml',
                menu: 'FinishProductDetails',
                data: {
                    action: "detail"
                }
            })

    }
})();
