(function () {
    'use strict';

    angular
        .module('production')
        .controller('finishProductRequisitionController', finishProductRequisitionController);

    finishProductRequisitionController.$inject = ['$location'];

    function finishProductRequisitionController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'finishProductRequisitionController';

        activate();

        function activate() { }
    }
})();
