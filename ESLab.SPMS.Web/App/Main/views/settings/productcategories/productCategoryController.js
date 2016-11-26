(function () {
    'use strict';

    angular
        .module('main')
        .controller('productCategoryController', productCategoryController);

    productCategoryController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.productCategory'];

    function productCategoryController($scope, $location, appSession, productCategoryService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Product Category';
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
              { name: 'CategoryCode', field: 'categoryCode' },
              { name: 'CategoryName', field: 'categoryName' },
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


        vm.addNewProductCategory = function () {                           //full function need to check
            abp.ui.setBusy(
                    null,
                    productCategoryService.createProductCategory(
                        vm.productCategory
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductCategoryCreatedMessage"), vm.productCategory.categoryName));
                        activate();

                    })
                );
        };
        vm.deleteProductCategory = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };
            abp.ui.setBusy(
                    null,
                    productCategoryService.deleteProductCategory(
                    data
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductCategoryDeletedMessage"), vm.productCategory.categoryName));
                        activate();

                    })
                );
        };

        vm.getProductCategories = function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    productCategoryService.getAllProductCategories().success(function (data) {
                        vm.gridOptions.data = data.productCategories;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.productCategory = vm.selectedRowEntity;
        }

        vm.updateProductCategory = function () {
            abp.ui.setBusy(
                    null,
                    productCategoryService.updateProductCategory(
                        vm.productCategory
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ProductCategoryUpdatedMessage"), vm.productCategory.categoryName));
                        activate();
                    })
                );
        };

        vm.saveProductCategory = function () {           
            if (vm.productCategory.id != 0) {
                vm.updateProductCategory();
            }
            else {
                vm.addNewProductCategory();
            }

        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.productCategory = {
                id: 0,
                categoryCode: '',
                categoryName: '',
                creatorUserId: appSession.user.id
            };
            vm.getProductCategories();
        }
    }
})();