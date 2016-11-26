(function () {
    'use strict';

    angular
        .module('main')
        .controller('warehouseController', warehouseController);

    warehouseController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.warehouse'];

    function warehouseController($scope, $location, appSession, warehouseService) {
        var vm = this;
        vm.title = 'Warehouse';
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
              { name: 'WarehouseCode', field: 'warehouseCode' },
              { name: 'WarehouseName', field: 'warehouseName' },
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


        vm.addNewWarehouse = function () {
            abp.ui.setBusy(
                    null,
                    warehouseService.createWarehouse(
                        vm.warehouse
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("WarehouseCreatedMessage"), vm.warehouse.warehouseName));
                        activate();

                    })
                );
        };
        vm.deleteWarehouse = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };
            abp.ui.setBusy(
                    null,
                    warehouseService.deleteWarehouse(
                    data
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("WarehouseDeletedMessage"), vm.warehouse.warehouseName));
                        activate();

                    })
                );
        };

        vm.getWarehouses = function () {
            abp.ui.setBusy(
                    null,
                    warehouseService.getAllWarehouses().success(function (data) {
                        vm.gridOptions.data = data.warehouses;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.warehouse = vm.selectedRowEntity;
        }

        vm.updateWarehouse = function () {
            abp.ui.setBusy(
                    null,
                    warehouseService.updateWarehouse(
                        vm.warehouse
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("WarehouseUpdatedMessage"), vm.warehouse.warehouseName));
                        activate();
                    })
                );
        };

        vm.saveWarehouse = function () {
            if (vm.warehouse.id != 0) {
                vm.updateWarehouse();
            }
            else {
                vm.addNewWarehouse();
            }

        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.warehouse = {
                id: 0,
                warehouseCode: '',
                warehouseName: '',
                creatorUserId: appSession.user.id
            };
            vm.getWarehouses();
        }
    }
})();