(function () {
    'use strict';

    angular
        .module('main')
        .controller('rawMaterialController', rawMaterialController);

    rawMaterialController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.rawMaterial', 'abp.services.app.rawMaterialType',
        'abp.services.app.productUnit', 'abp.services.app.brand'];

    function rawMaterialController($scope, $location, appSession, rawMaterialService, rawMaterialTypeService, productUnitService, brandService) {
        var vm = this;
        vm.title = 'Raw Material';
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
              { name: 'RawMaterialTypeId', field: 'rawMaterialTypeId', visible: false },
              { name: 'BrandId', field: 'BrandId', visible: false },
              { name: 'productUnitId', field: 'productUnitId', visible: false },
              { name: 'ProductName', field: 'productName' },
              { name: 'RawMaterialTypeName', field: 'rawMaterialTypeName' },
              { name: 'BrandName', field: 'brandName' },
              { name: 'UnitName', field: 'unitName' },
              { name: 'Model', field: 'model' },
              { name: 'Size', field: 'size' },
              { name: 'Color', field: 'color' },
              { name: 'Origin', field: 'origin' },
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


        vm.addNewRawMaterial = function () {
            vm.rawMaterial.rawMaterialTypeId = vm.selectedRawMaterialType.id;
            vm.rawMaterial.brandId = vm.selectedBrand.id;
            vm.rawMaterial.productUnitId = vm.selectedProductUnit.id;
            abp.ui.setBusy(
                    null,
                    rawMaterialService.createRawMaterial(
                        vm.rawMaterial
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("RawMaterialCreatedMessage"), vm.rawMaterial.productName));
                        activate();

                    })
                );
        };
        vm.deleteRawMaterial = function () {
            var data = {
                id: vm.selectedRowEntity.id
            };
            abp.ui.setBusy(
                    null,
                    rawMaterialService.deleteRawMaterial(
                    data
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("RawMaterialDeletedMessage"), vm.rawMaterial.productName));
                        activate();

                    })
                );
        };

        vm.getRawMaterials = function () {
            abp.ui.setBusy(
                    null,
                    rawMaterialService.getAllRawMaterials().success(function (data) {
                        vm.gridOptions.data = data.rawMaterials;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.rawMaterial = vm.selectedRowEntity;
            vm.selectedRawMaterialType.id = vm.rawMaterial.rawMaterialTypeId;
            vm.selectedBrand.id = vm.rawMaterial.brandId;
            vm.selectedProductUnit.id = vm.rawMaterial.productUnitId;
        }

        vm.updateRawMaterial = function () {
            vm.rawMaterial.rawMaterialTypeId = vm.selectedRawMaterialType.id;
            vm.rawMaterial.brandId = vm.selectedBrand.id;
            vm.rawMaterial.productUnitId = vm.selectedProductUnit.id;
            abp.ui.setBusy(
                    null,
                    rawMaterialService.updateRawMaterial(
                        vm.rawMaterial
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("RawMaterialUpdatedMessage"), vm.rawMaterial.productName));
                        activate();
                    })
                );
        };

        vm.getRawMaterialTypes = function () {
            abp.ui.setBusy(
                    null,
                    rawMaterialTypeService.getAllRawMaterialTypes().success(function (data) {
                        vm.rawMaterialTypes = data.rawMaterialTypes;
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

        vm.getRawMaterialTypeBrands = function () {
            var data = {
                "brandType": 0
            };

            abp.ui.setBusy(
                    null,
                    brandService.getBrandsByBrandType(data).success(function (data) {
                        vm.brands = data.brands;
                    })
                );
        };
        vm.saveRawMaterial = function () {
            if (vm.rawMaterial.id != 0) {
                vm.updateRawMaterial();
            }
            else {
                vm.addNewRawMaterial();
            }

        };

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.rawMaterial = {
                id: 0,
                rawMaterialTypeId: '',
                brandId: '',
                productName: '',
                productUnitId: '',
                model: '',
                size: '',
                color: '',
                origin: '',
                reOrderPoint: '',
                creatorUserId: appSession.user.id
            };

            vm.rawMaterialTypes = {};
            vm.selectedRawMaterialType = {
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
            
            vm.getRawMaterialTypes();
            vm.getProductUnits();
            vm.getRawMaterialTypeBrands();
            vm.getRawMaterials();
        }
    }
})();