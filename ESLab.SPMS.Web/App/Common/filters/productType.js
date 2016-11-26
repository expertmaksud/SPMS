(function () {
    'use strict';

    angular
        .module('common')
        .filter('productType', productType);
    
    function productType(productTypeFactory) {
        return productTypeFilter;

        function productTypeFilter(input) {
            var data = productTypeFactory.getData();
            return data[input].name;
        }
    }
})();