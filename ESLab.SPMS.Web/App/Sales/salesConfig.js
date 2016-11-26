(function () {
    'use strict';

    angular
        .module('sales')
        .config(configure);

    configure.$inject = ['$stateProvider', '$urlRouterProvider'];

    function configure($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
       


    }
})();
