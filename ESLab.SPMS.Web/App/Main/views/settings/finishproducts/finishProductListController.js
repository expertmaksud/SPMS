(function () {
    'use strict';

    angular
        .module('main')
        .controller('finishProductListController', finishProductListController);

    finishProductListController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.finishProduct', 'abp.services.app.productGrade',
        'abp.services.app.productApi', 'abp.services.app.productCategory', 'abp.services.app.productUnit', 'abp.services.app.brand'];

    function finishProductListController($scope, $location, appSession, finishProductService, productGradeService,
        productApiService, productCategoryService, productUnitService, brandService) {
        var vm = this;
        vm.title = 'Finish Product List';
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
              { name: 'BrandId', field: 'BrandId', visible: false },
              { name: 'ProductGradeId', field: 'productGradeId', visible: false },
              { name: 'ProductApiId', field: 'productApiId', visible: false },
              { name: 'ProductCategoryId', field: 'productCategoryId', visible: false },
              { name: 'productUnitId', field: 'productUnitId', visible: false },
              { name: 'ProductName', field: 'productName' },
              { name: 'BrandName', field: 'brandName' },
              { name: 'ProductGradeName', field: 'productGradeName' },
              { name: 'ProductApiName', field: 'productApiName' },
              { name: 'ProductCategoryName', field: 'productCategoryName' },
              { name: 'PackSize', field: 'packSize' },
              { name: 'Multiplier', field: 'multiplier' },
              { name: 'ProductUnitName', field: 'productUnitName' },
              { name: 'Mrp', field: 'mrp' },
              { name: 'ReOrderPoint', field: 'reOrderPoint' },
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


        vm.getFinishProducts = function () {
            abp.ui.setBusy(
                    null,
                    finishProductService.getAllFinishProducts().success(function (data) {
                        vm.gridOptions.data = data.finishProducts;
                    })
                );
        };

        vm.getProductGrades = function () {
            abp.ui.setBusy(
                    null,
                    productGradeService.getAllProductGrades().success(function (data) {
                        vm.productGrades = data.productGrades;
                    })
                );
        };

        vm.getProductApis = function () {
            abp.ui.setBusy(
                    null,
                    productApiService.getAllProductApis().success(function (data) {
                        vm.productApis = data.productApis;
                    })
                );
        };

        vm.getProductCategories = function () {
            abp.ui.setBusy(
                    null,
                    productCategoryService.getAllProductCategories().success(function (data) {
                        vm.productCategories = data.productCategories;
                    })
                );
        };

        vm.getProductUnits = function () {
            abp.ui.setBusy(
                    null,
                    productUnitService.getAllProductUnits().success(function (data) {
                        vm.productUnits = data.productUnits;
                    })
                );
        };

        vm.getFinishProductTypeBrands = function () {
            var data = {
                "brandType": 1
            };

            abp.ui.setBusy(
                    null,
                    brandService.getBrandsByBrandType(data).success(function (data) {
                        vm.brands = data.brands;
                    })
                );
        };

        vm.displayFinishProductDetails = function () {

            var finishProductId = angular.copy(vm.selectedRowEntity.id);
            vm.disableEdit = true;
            $location.path('/finishproduct/detail/' + finishProductId);
        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.finishProduct = {
                id: 0,
                brandId: '',
                productName: '',
                productGradeId: '',
                productApiId: '',
                productCategoryId: '',
                productUnitId: '',
                packSize: '',
                multiplier: '',
                mrp: '',
                reOrderPoint: '',
                creatorUserId: appSession.user.id
            };

            vm.productGrades = {};
            vm.selectedProductGrade = {
                id: ''
            };

            vm.productApis = {};
            vm.selectedProductApi = {
                id: ''
            };

            vm.productCategories = {};
            vm.selectedProductCategory = {
                id: ''
            };

            vm.productUnits = {};
            vm.selectedProductUnit = {
                id: ''
            };

            vm.brands = {};
            vm.selectedBrand = {
                id: ''
            };

            vm.getProductUnits();
            vm.getProductGrades();
            vm.getProductApis();
            vm.getProductCategories();
            vm.getFinishProductTypeBrands();
            vm.getFinishProducts();
        }
    }
})();