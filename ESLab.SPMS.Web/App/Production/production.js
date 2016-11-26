(function () {
    'use strict';

    angular.module('production', [
        // Angular modules 
        'ngAnimate',
        'ngSanitize',
        'ngMessages',


        // Custom modules 
        'abp',
        'common',

        // 3rd Party Modules
        'ui.router',
        'ui.grid',
        'ui.grid.edit',
        'ui.grid.selection'
        
    ]);
})();