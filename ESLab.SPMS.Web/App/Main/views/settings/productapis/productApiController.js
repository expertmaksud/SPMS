(function () {
    'use strict';

    angular
        .module('main')
        .controller('productApiController', productApiController);

    productApiController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.productApi'];

    function productApiController($scope, $location, appSession, productApiService) {
        var vm = this;
        vm.title = 'Product API';
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
              { name: 'ApiCode', field: 'apiCode' },
              { name: 'ApiName', field: 'apiName' },
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


        vm.addNewProductApi = function () {
            abp.ui.setBusy(
                    null,
                    productApiService.createProductApi(
                        vm.productApi
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductApiCreatedMessage"), vm.productApi.apiName));
                        activate();

                    })
                );
        };
        vm.deleteProductApi = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };
            abp.ui.setBusy(
                    null,
                    productApiService.deleteProductApi(
                    data
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductApiDeletedMessage"), vm.productApi.apiName));
                        activate();

                    })
                );
        };

        vm.getProductApis = function () {
            abp.ui.setBusy(
                    null,
                    productApiService.getAllProductApis().success(function (data) {
                        vm.gridOptions.data = data.productApis;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.productApi = vm.selectedRowEntity;
        }

        vm.updateProductApi = function () {
            abp.ui.setBusy(
                    null,
                    productApiService.updateProductApi(
                        vm.productApi
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductApiUpdatedMessage"), vm.productApi.apiName));
                        activate();
                    })
                );
        };

        vm.saveProductApi = function () {
            if (vm.productApi.id != 0) {
                vm.updateProductApi();
            }
            else {
                vm.addNewProductApi();
            }

        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.productApi = {
                id: 0,
                apiCode: '',
                apiName: '',
                creatorUserId: appSession.user.id
            };
            vm.getProductApis();
        }
    }
})();