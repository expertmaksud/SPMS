(function () {
    'use strict';

    var app = angular.module('app', [
        
        //Custom Module
        'main',
        'procurement',
        'inventory',
        'production',
        'sales',
        'finance',
        'common',
       

        // 3rd Party Module
        'ui.router',
        'ui.bootstrap',
        'ui.jq',
        'ui.select',
        
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$urlRouterProvider', 'uiSelectConfig',
    function ($urlRouterProvider, uiSelectConfig) {
        $urlRouterProvider.otherwise('/');
        

        uiSelectConfig.theme = 'bootstrap';
        uiSelectConfig.resetSearchInput = true;
        uiSelectConfig.appendToBody = true;
    }
    ]);
})();