(function () {
    'use strict';

    angular
        .module('production')
        .config(configure);

    configure.$inject = ['$stateProvider', '$urlRouterProvider'];

    function configure($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
        $stateProvider
            .state('newFinishProduct', {
                url: '/product/new',
                templateUrl: '/App/Production/views/finishproductrequisition/new.cshtml',
                menu: 'NewFinishProduct'
            })
             
         


    }

})();