(function () {
    'use strict';

    angular
        .module('common')
        .factory('stockTypeFactory', stockTypeFactory);

    stockTypeFactory.$inject = ['$http'];

    function stockTypeFactory($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() {
            var stockType = [{ id: '0', name: 'Good' },
                 { id: '1', name: 'Damage' },
            { id: 2, name: ' Scrap' }];
            return stockType;
        }
    }
})();