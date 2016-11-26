(function () {
    'use strict';

    angular
        .module('common')
        .factory('brandTypeFactory', brandTypeFactory);

    brandTypeFactory.$inject = ['$http'];

    function brandTypeFactory($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() {
            var brandType = [{ id: '0', name: 'Raw Material' },
                                { id: '1', name: 'Finish Product' }];
            return brandType;
        }
    }
})();