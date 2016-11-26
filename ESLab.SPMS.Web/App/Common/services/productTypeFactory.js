(function () {
    'use strict';

    angular
        .module('common')
        .factory('productTypeFactory', productTypeFactory);

    productTypeFactory.$inject = ['$http'];

    function productTypeFactory($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() {
            var productType = [{ id: '0', name: 'RawMaterial' },
                        { id: '1', name: 'FinishProduct' }];
            return productType;
        }
    }
})();