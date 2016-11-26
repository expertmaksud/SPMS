(function () {
    'use strict';

    angular
        .module('common')
        .directive('uniqueCode', uniqueCode);

    uniqueCode.$inject = ['$window'];

    function uniqueCode($window) {
        // Usage:
        //     <uniquebrandcode></uniquebrandcode>
        // Creates:
        // 
        var directive = {
            require: 'ngModel',
            link: link,
            restrict: 'A',
            scope: {
                serviceName: '@'
            },
        };
        return directive;

        function link(scope, element, attrs, ngModel) {

            element.bind('blur', function (e) {
                if (!ngModel || !element.val()) return;

                var serviceInstance = element.injector().get(scope.serviceName);
                var currentValue = element.val();
                var data = {
                    "code": currentValue
                }
                serviceInstance.getByCode(data).success(function (data) {

                    var unique = true;
                    if (data != null)
                        unique = false;

                    console.log('unique = ' + data);
                    ngModel.$setValidity('unique', unique);
                    scope.$broadcast('show-errors-check-validity');
                });
            });

        }
    }

})();