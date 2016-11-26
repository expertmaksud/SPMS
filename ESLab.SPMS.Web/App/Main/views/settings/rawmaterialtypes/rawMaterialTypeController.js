(function () {
    'use strict';

    angular
        .module('main')
        .controller('rawMaterialTypeController', rawMaterialTypeController);

    rawMaterialTypeController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.rawMaterialType'];

    function rawMaterialTypeController($scope, $location, appSession, rawMaterialTypeService) {
        var vm = this;
        vm.title = 'Raw Material Type';
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
              { name: 'RawMaterialTypeCode', field: 'rawMaterialTypeCode' },
              { name: 'RawMaterialTypeName', field: 'rawMaterialTypeName' },
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


        vm.addNewRawMaterialType = function () {
            abp.ui.setBusy(
                    null,
                    rawMaterialTypeService.createRawMaterialType(
                        vm.rawMaterialType
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("RawMaterialTypeCreatedMessage"), vm.rawMaterialType.rawMaterialTypeName));
                        activate();

                    })
                );
        };
        vm.deleteRawMaterialType = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };

            abp.message.confirm(
            'This Raw Material Type will be deleted.',
            'Are you sure?',
             function (isConfirmed) {
                if (isConfirmed) {
                    abp.ui.setBusy(
                        null,
                        rawMaterialTypeService.deleteRawMaterialType(
                        data
                        ).success(function () {
                            abp.notify.info(abp.utils.formatString(localize("RawMaterialTypeDeletedMessage"), vm.rawMaterialType.rawMaterialTypeName));
                            activate();

                        })
                    );
                }
            });

        };

        vm.getRawMaterialTypes = function () {
            abp.ui.setBusy(
                    null,
                    rawMaterialTypeService.getAllRawMaterialTypes().success(function (data) {
                        vm.gridOptions.data = data.rawMaterialTypes;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.rawMaterialType = vm.selectedRowEntity;
        }

        vm.updateRawMaterialType = function () {
            abp.ui.setBusy(
                    null,
                    rawMaterialTypeService.updateRawMaterialType(
                        vm.rawMaterialType
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("RawMaterialTypeUpdatedMessage"), vm.rawMaterialType.rawMaterialTypeName));
                        activate();
                    })
                );
        };

        vm.saveRawMaterialType = function () {
            if (vm.rawMaterialType.id != 0) {
                vm.updateRawMaterialType();
            }
            else {
                vm.addNewRawMaterialType();
            }

        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.rawMaterialType = {
                id: 0,
                rawMaterialTypeCode: '',
                rawMaterialTypeName: '',
                creatorUserId: appSession.user.id
            };
            vm.getRawMaterialTypes();
        }
    }
})();