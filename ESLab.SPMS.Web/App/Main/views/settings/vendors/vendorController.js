(function () {
    'use strict';

    angular
        .module('main')
        .controller('vendorController', vendorController);

    vendorController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.vendor'];

    function vendorController($scope, $location, appSession, vendorService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Vendor';
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
              { name: 'VendorCode', field: 'vendorCode' },
              { name: 'VendorName', field: 'vendorName' },
              { name: 'VendorAddress', field: 'vendorAddress' },
              { name: 'VendorContactPerson', field: 'vendorContactPerson' },
              { name: 'VendorContactNumber', field: 'vendorContactNumber' },
              { name: 'VendorContactEmail', field: 'vendorContactEmail' },
              { name: 'VendorWebsite', field: 'vendorWebsite' },
              { name: 'VendorFax', field: 'vendorFax' },
              { name: 'VendorBankDetails', field: 'vendorBankDetails' },
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


        vm.addNewVendor = function () {
            abp.ui.setBusy(
                    null,
                    vendorService.createVendor(
                        vm.vendor
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("VendorCreatedMessage"), vm.vendor.vendorName));
                        activate();
                    })
                );
        };

        vm.getVendors = function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    vendorService.getAllVendors().success(function (data) {
                        vm.gridOptions.data = data.vendors;
                    })
                );
        };

        vm.editSelectedRow = function () {
            $scope.newVendorForm.$valid = true;
            vm.vendor = vm.selectedRowEntity;
        }

        vm.updateVendor = function () {
            abp.ui.setBusy(
                    null,
                    vendorService.updateVendor(
                        vm.vendor
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("VendorUpdatedMessage"), vm.vendor.vendorName));
                        activate();                   
                    })
                );
        };

        vm.saveVendor = function () {
            if (vm.vendor.id != 0) {
                vm.updateVendor();
            }
            else {
                vm.addNewVendor();
            }

        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.vendor = {
                id: 0,
                vendorCode: '',
                vendorName: '',
                vendorAddress: '',
                vendorContactPerson: '',
                vendorContactNumber: '',
                vendorContactEmail: '',
                vendorWebsite: '',
                vendorFax: '',
                vendorBankDetails: '',
                creatorUserId: appSession.user.id
            };
            vm.getVendors();
        }
    }
})();