(function () {
    'use strict';

    angular
        .module('main')
        .controller('finishProductWithFormulaController', finishProductWithFormulaController);

    finishProductWithFormulaController.$inject = ['$scope', '$location', 'appSession', '$state', '$stateParams', 'abp.services.app.finishProduct', 'abp.services.app.finishProductFormula', 'abp.services.app.productGrade',
        'abp.services.app.rawMaterial', 'abp.services.app.productApi', 'abp.services.app.productCategory', 'abp.services.app.productUnit', 'abp.services.app.brand', 'uiGridConstants'];

    function finishProductWithFormulaController($scope, $location, appSession, $state, $stateParams, finishProductService, finishProductFormulaService, productGradeService,
        rawMaterialService, productApiService, productCategoryService, productUnitService, brandService, uiGridConstants) {
        var vm = this;
        vm.title = 'Finish Product With Formula';
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
              { name: 'FinishProductId', field: 'finishProductId', visible: false },
              { name: 'RawMaterialId', field: 'rawMaterialId', visible: false },
              { name: 'FullProductName', field: 'fullProductName' },
              {
                  name: 'Percentage', field: 'percentage'
              }
            ],
            onRegisterApi: function (gridApi) {
                vm.myGridApi = gridApi;
                vm.myGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    vm.disableEdit = false;
                    vm.selectedRowEntity = angular.copy(row.entity);
                });
            }
        };


        vm.addNewFinishProductWithFormula = function () {
            vm.finishProduct.brandId = vm.selectedBrand.id;
            vm.finishProduct.productGradeId = vm.selectedProductGrade.id;
            vm.finishProduct.productApiId = vm.selectedProductApi.id;
            vm.finishProduct.productCategoryId = vm.selectedProductCategory.id;
            vm.finishProduct.productUnitId = vm.selectedProductUnit.id;

            vm.finishProduct.finishProductFormulaItems = vm.finishProductFormulaItems;

            abp.ui.setBusy(
                    null,
                    finishProductService.createFinishProduct(
                        vm.finishProduct
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("FinishProductCreatedMessage"), vm.finishProduct.productName));
                        $location.path('/FinishProductList');

                    })
                );
        };
        vm.deleteFinishProduct = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };
            abp.ui.setBusy(
                    null,
                    finishProductService.deleteFinishProduct(
                    data
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("FinishProductDeletedMessage"), vm.finishProduct.productName));
                        activate();

                    })
                );
        };

        vm.getFinishProducts = function () {
            abp.ui.setBusy(
                    null,
                    finishProductService.getAllFinishProducts().success(function (data) {
                        //vm.gridOptions.data = data.finishProducts;
                    })
                );
        };

        //vm.editSelectedRow = function () {
        //    vm.finishProduct = vm.selectedRowEntity;
        //    vm.selectedBrand.id = vm.finishProduct.brandId;
        //    vm.selectedProductGrade.id = vm.finishProduct.productGradeId;
        //    vm.selectedProductApi.id = vm.finishProduct.productApiId;
        //    vm.selectedProductCategory.id = vm.finishProduct.productCategoryId;
        //    vm.selectedProductUnit.id = vm.finishProduct.productUnitId;
        //}

        //vm.updateFinishProduct = function () {
        //    vm.finishProduct.brandId = vm.selectedBrand.id;
        //    vm.finishProduct.productGradeId = vm.selectedProductGrade.id;
        //    vm.finishProduct.productApiId = vm.selectedProductApi.id;
        //    vm.finishProduct.productCategoryId = vm.selectedProductCategory.id;
        //    vm.finishProduct.productUnitId = vm.selectedProductUnit.id;
        //    abp.ui.setBusy(
        //            null,
        //            finishProductService.updateFinishProduct(
        //                vm.finishProduct
        //            ).success(function () {
        //                abp.notify.info(abp.utils.formatString(localize("FinishProductUpdatedMessage"), vm.finishProduct.productName));
        //                activate();
        //            })
        //        );
        //};

        vm.addToGrid = function () {
            
            vm.finishProductFormulaItem.fullProductName = vm.selectedRawMaterial.fullProductName;
            vm.finishProductFormulaItem.rawMaterialId = vm.selectedRawMaterial.id;

            vm.totalPercentage = parseFloat(vm.totalPercentage) + parseFloat(vm.finishProductFormulaItem.percentage);

            if (!newFinishProductWithFormula.$invalid && vm.totalPercentage === 100)
            {
                vm.disableSaveNew = false;
            }
            else
            {
                vm.disableSaveNew = true;
            }

            vm.finishProductFormulaItems.push(angular.copy(vm.finishProductFormulaItem));
            vm.finishProductFormulaItem.id = vm.finishProductFormulaItem.id + 1;
            vm.gridOptions.data = vm.finishProductFormulaItems;

            vm.finishProductFormulaItem = {
                id: vm.finishProductFormulaItem.id,
                finishProductId: '',
                rawMaterialId: '',
                percentage: ''
            };
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

        vm.getRawMaterials = function () {
            abp.ui.setBusy(
                    null,
                    rawMaterialService.getAllRawMaterials().success(function (data) {
                        vm.rawMaterials = data.rawMaterials;
                    })
                );
        };

        vm.saveFinishProduct = function () {
            if (vm.finishProduct.id != 0) {
                vm.updateFinishProduct();
            }
            else {
                vm.addNewFinishProductWithFormula();
            }

        };

        vm.getFinishProductDetailsById = function (id) {
            var data = {
                id: id
            };
            abp.ui.setBusy(
                    null,
                    finishProductService.getFinishProductDetailsById(data).success(function (data) {

                        vm.finishProduct = data.finishProduct;
                        
                        vm.selectedBrand.id = vm.finishProduct.brandId;
                        vm.selectedProductGrade.id = vm.finishProduct.productGradeId;
                        vm.selectedProductApi.id = vm.finishProduct.productApiId;
                        vm.selectedProductCategory.id = vm.finishProduct.productCategoryId;
                        vm.selectedProductUnit.id = vm.finishProduct.productUnitId;

                        vm.finishProductFormulaItems = data.finishProductFormulaItems;

                        vm.gridOptions.data = vm.finishProductFormulaItems;
                    })
                );
        };

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.disableSaveNew = true;
            //vm.disableAddToGrid = true;

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

            vm.totalPercentage = 0;

            vm.selectedRawMaterials = {};
            vm.selectedRawMaterial = {
                id: ''
            };
            vm.finishProductFormulaItems = [];

            vm.finishProductFormulaItem = {
                id: 0,
                finishProductId: '',
                rawMaterialId: '',
                percentage: '',
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
            vm.getRawMaterials();           


            if ($state.current.data != undefined) {
                if ($state.current.data.action === 'edit' || $state.current.data.action === 'detail') {
                    vm.getFinishProductDetailsById($stateParams.id);
                }
            }
            
        }
    }
})();