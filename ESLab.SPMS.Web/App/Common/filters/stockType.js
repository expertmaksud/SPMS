(function () {
    'use strict';

    angular
        .module('common')
        .filter('stockType', stockType);
    
    function stockType(stockTypeFactory) {
        return stockTypeFilter;

        function stockTypeFilter(input) {
            var data = stockTypeFactory.getData();
            return data[input].name;
        }
    }
})();