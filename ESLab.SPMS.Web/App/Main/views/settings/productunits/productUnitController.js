(function () {
    'use strict';

    angular
        .module('main')
        .controller('productUnitController', productUnitController);

    productUnitController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.productUnit'];

    function productUnitController($scope, $location, appSession, productUnitService) {
        var vm = this;
        vm.title = 'Product Unit';
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
              { name: 'UnitCode', field: 'unitCode' },
              { name: 'UnitName', field: 'unitName' },
              { name: 'UnitToKg', field: 'unitToKg' },
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

        vm.addNewProductUnit = function () {
            abp.ui.setBusy(
                    null,
                    productUnitService.createProductUnit(
                        vm.productUnit
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductUnitCreatedMessage"), vm.productUnit.unitName));
                        activate();
                    })
                );
        };
        vm.deleteProductUnit = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };

            abp.message.confirm(
            'This product unit will be deleted.',
            'Are you sure?',
             function (isConfirmed) {
                 if (isConfirmed) {
                     abp.ui.setBusy(
                             null,
                             productUnitService.deleteProductUnit(
                             data
                             ).success(function () {
                                 abp.notify.info(abp.utils.formatString(localize("ProductUnitDeletedMessage"), vm.productUnit.unitName));
                                 activate();
                             })
                         );
                    }
                }
            );
        };

        vm.getProductUnits = function () {
            abp.ui.setBusy(
                    null,
                    productUnitService.getAllProductUnits().success(function (data) {
                        vm.gridOptions.data = data.productUnits;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.productUnit = vm.selectedRowEntity;
        }

        vm.updateProductUnit = function () {
            abp.ui.setBusy(
                    null,
                    productUnitService.updateProductUnit(
                        vm.productUnit
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductUnitUpdatedMessage"), vm.productUnit.unitName));
                        activate();
                    })
                );
        };

        vm.saveProductUnit = function () {
            if (vm.productUnit.id != 0) {
                vm.updateProductUnit();
            }
            else {
                vm.addNewProductUnit();
            }
        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.productUnit = {
                id: 0,
                unitCode: '',
                unitName: '',
                unitToKg: '',
                creatorUserId: appSession.user.id
            };
            vm.getProductUnits();
        }
    }
})();