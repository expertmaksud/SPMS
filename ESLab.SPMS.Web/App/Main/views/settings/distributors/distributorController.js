(function () {
    'use strict';

    angular
        .module('main')
        .controller('distributorController', distributorController);

    distributorController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.distributor'];

    function distributorController($scope, $location, appSession, distributorService) {
        var vm = this;
        vm.title = 'Distributor';
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
              { name: 'DistributorCode', field: 'distributorCode' },
              { name: 'DistributorName', field: 'distributorName' },
              { name: 'DistributorCity', field: 'distributorCity' },
              { name: 'DistributorContactPerson', field: 'distributorContactPerson' },
              { name: 'DistributorMobileNumber', field: 'distributorMobileNumber' },
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


        vm.addNewDistributor = function () {
            abp.ui.setBusy(
                    null,
                    distributorService.createDistributor(
                        vm.distributor
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("DistributorCreatedMessage"), vm.distributor.distributorName));
                        activate();

                    })
                );
        };
        vm.deleteDistributor = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };
            abp.ui.setBusy(
                    null,
                    distributorService.deleteDistributor(
                    data
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("DistributorDeletedMessage"), vm.distributor.distributorName));
                        activate();

                    })
                );
        };

        vm.getDistributors = function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    distributorService.getAllDistributors().success(function (data) {
                        vm.gridOptions.data = data.distributors;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.distributor = vm.selectedRowEntity;
        }

        vm.updateDistributor = function () {
            abp.ui.setBusy(
                    null,
                    distributorService.updateDistributor(
                        vm.distributor
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("DistributorUpdatedMessage"), vm.distributor.distributorName));
                        activate();
                    })
                );
        };

        vm.saveDistributor = function () {
            if (vm.distributor.id != 0) {
                vm.updateDistributor();
            }
            else {
                vm.addNewDistributor();
            }

        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.distributor = {
                id: 0,
                distributorCode: '',
                distributorName: '',
                creatorUserId: appSession.user.id
            };
            vm.getDistributors();
        }
    }
})();