(function () {
    'use strict';

    angular
        .module('procurement')
        .controller('purchaseListController', purchaseListController);

    purchaseListController.$inject = ['$scope', '$location', 'abp.services.procurement.purchase', 'purchaseTypeFactory'];

    function purchaseListController($scope, $location, purchaseService, purchaseTypeFactory) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'purchaseListController';

        vm.gridOptions = {
            enableSorting: true,
            enableRowSelection: true,
            showSelectionCheckbox: true,
            enableSelectAll: false,
            multiSelect: false,
            enableCellEdit: false,
            columnDefs: [
              { name: 'SL#', field: 'id', visible: false },
              { name: 'Type', field: 'purchaseType', cellFilter: 'purchaseType' },
              { name: 'LcNumber', field: 'lcNumber' },
              { name: 'LcDate', field: 'lcDate', type: 'date', cellFilter: 'date:"dd-MMM-yyyy "' },
              { name: 'PoNumber', field: 'poNumber' },
              { name: 'PoDate', field: 'poDate', type: 'date', cellFilter: 'date:"dd-MMM-yyyy "' },
              { name: 'Etd', field: 'etd', type: 'date', cellFilter: 'date:"dd-MMM-yyyy "' },
              { name: 'Eta', field: 'eta', type: 'date', cellFilter: 'date:"dd-MMM-yyyy "' },
              { name: 'Vendor', field: 'vendorName' },
              { name: 'Status', field: 'status', visible: false },
              { name: 'Remarks', field: 'remarks', visible: false }
            ],
            onRegisterApi: function (gridApi) {
                vm.myGridApi = gridApi;
                vm.myGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    vm.disableEdit = false;
                    vm.selectedRowEntity = angular.copy(row.entity);
                });
            }
        };

        vm.getPurchases = function () {
            abp.ui.setBusy(
                    null,
                    purchaseService.getAllPurchases().success(function (data) {
                        vm.gridOptions.data = data.purchases;
                    })
                );
        };

        vm.editSelectedRow = function () {

            var purchesId = angular.copy(vm.selectedRowEntity.id);
            vm.disableEdit = true;
            $location.path('/purchase/edit/' + purchesId);
        }

        vm.displayDetails = function () {

            var purchesId = angular.copy(vm.selectedRowEntity.id);
            vm.disableEdit = true;
            $location.path('/purchase/detail/' + purchesId);
        }
        activate();

        function activate() {
            vm.getPurchases();
            vm.disableEdit = true;
        }
    }
})();