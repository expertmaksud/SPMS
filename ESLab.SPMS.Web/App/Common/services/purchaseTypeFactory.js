(function () {
    'use strict';

    angular
        .module('common')
        .factory('purchaseTypeFactory', purchaseTypeFactory);

    purchaseTypeFactory.$inject = ['$http'];

    function purchaseTypeFactory($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() {
            var purchaseType = [{ id: '0', name: 'Local' },
                        { id: '1', name: 'Import' }];
            return purchaseType;
        }
    }
})();