(function () {
    'use strict';

    angular
        .module('common')
        .filter('purchaseType', purchaseType);
    
    function purchaseType(purchaseTypeFactory) {
        return purchaseTypeFilter;

        function purchaseTypeFilter(input) {
            var data = purchaseTypeFactory.getData();
            return data[input].name;
        }
    }
})();