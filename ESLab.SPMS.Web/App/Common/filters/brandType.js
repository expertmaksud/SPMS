(function () {
    'use strict';

    angular
        .module('common')
        .filter('brandType', brandType);

    function brandType(brandTypeFactory) {
        return brandTypeFilter;

        function brandTypeFilter(input) {
            var data = brandTypeFactory.getData();
            return data[input].name;
        }
    }
})();