(function () {
    'use strict';

    angular
        .module('main')
        .controller('productGradeController', productGradeController);

    productGradeController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.productGrade'];

    function productGradeController($scope, $location, appSession, productGradeService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'ProductGrade';
        var localize = abp.localization.getSource('SPMS');


        vm.gridOptions = {
            enableSorting: true,
            enableRowSelection: true,
            showSelectionCheckbox: true,
            enableSelectAll: false,
            multiSelect: false,
            enableCellEdit: false,
            columnDefs: [
              { name: 'Id', field: 'id', visible: false },
              { name: 'ProductGradeCode', field: 'gradeCode' },
              { name: 'ProductGradeName', field: 'gradeName' },
              { name: 'CreationTime', field: 'creationTime', type: 'date', cellFilter: 'date:"dd-MMM-yyyy h:m a"' }
            ],
            onRegisterApi: function (gridApi) {
                vm.myGridApi = gridApi;
                vm.myGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    vm.disableEdit = false;
                    vm.selectedRowEntity = angular.copy(row.entity);
                });

            }
        };


        vm.addNewProductGrade = function () {                           //full function need to check
            abp.ui.setBusy(
                    null,
                    productGradeService.createProductGrade(
                        vm.productGrade
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductGradeCreatedMessage"), vm.productGrade.gradeName));
                        activate();

                    })
                );
        };
        vm.deleteProductGrade = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };
            abp.message.confirm(
            'This Product Grade will be deleted.',
            'Are you sure?',
             function (isConfirmed) {
                 if (isConfirmed) {
                     abp.ui.setBusy(
                             null,
                             productGradeService.deleteProductGrade(
                                 data
                             ).success(function () {
                                 abp.notify.info(abp.utils.formatString(localize("ProductGradeDeletedMessage"), vm.productGrade.gradeName));
                                 activate();

                             })
                         );
                    }
                }
            );
        };

        vm.getProductGrades = function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    productGradeService.getAllProductGrades().success(function (data) {
                        vm.gridOptions.data = data.productGrades;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.productGrade = vm.selectedRowEntity;
        }

        vm.updateProductGrade = function () {
            abp.ui.setBusy(
                    null,
                    productGradeService.updateProductGrade(
                        vm.productGrade
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductGradeUpdatedMessage"), vm.productGrade.gradeName));
                        activate();
                        //$location.path('/ProductGrade');
                    })
                );
        };

        vm.saveProductGrade = function () {           //
            if (vm.productGrade.id != 0) {
                vm.updateProductGrade();
            }
            else {
                vm.addNewProductGrade();
            }

        };

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.productGrade = {
                id: 0,
                gradeCode: '',
                gradeName: '',
                creatorUserId: appSession.user.id
            };
            vm.getProductGrades();
        };
    }
})();