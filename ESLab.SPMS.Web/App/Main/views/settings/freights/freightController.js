(function () {
    'use strict';

    angular
        .module('main')
        .controller('freightController', freightController);

    freightController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.freight'];

    function freightController($scope, $location, appSession, freightService) {
        var vm = this;
        vm.title = 'Freight';
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
              { name: 'FreightCode', field: 'freightCode' },
              { name: 'FreightName', field: 'freightName' },
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


        vm.addNewFreight = function () {
            abp.ui.setBusy(
                    null,
                    freightService.createFreight(
                        vm.freight
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("FreightCreatedMessage"), vm.freight.freightName));
                        activate();

                    })
                );
        };
        vm.deleteFreight = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };
            abp.ui.setBusy(
                    null,
                    freightService.deleteFreight(
                    data
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("FreightDeletedMessage"), vm.freight.freightName));
                        activate();

                    })
                );
        };

        vm.getFreights = function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    freightService.getAllFreights().success(function (data) {
                        vm.gridOptions.data = data.freights;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.freight = vm.selectedRowEntity;
        }

        vm.updateFreight= function () {
            abp.ui.setBusy(
                    null,
                    freightService.updateFreight(
                        vm.freight
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("FreightUpdatedMessage"), vm.freight.freightName));
                        activate();
                    })
                );
        };

        vm.saveFreight= function () {
            if (vm.freight.id != 0) {
                vm.updateFreight();
            }
            else {
                vm.addNewFreight();
            }

        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.freight = {
                id: 0,
                freightCode: '',
                freightName: '',
                creatorUserId: appSession.user.id
            };
            vm.getFreights();
        }
    }
})();