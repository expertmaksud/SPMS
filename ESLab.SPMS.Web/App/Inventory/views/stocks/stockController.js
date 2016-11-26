(function () {
    'use strict';

    angular
        .module('inventory')
        .controller('stockController', stockController);

    stockController.$inject = ['$scope', '$location', '$filter', '$state', '$stateParams', 'abp.services.procurement.purchase', 'abp.services.procurement.purchaseItem',
        'purchaseTypeFactory', 'purchaseTypeFilter', 'abp.services.app.warehouse', 'stockTypeFactory', 'abp.services.inventory.stock'];

    function stockController($scope, $location, $filter, $state, $stateParams, purchaseService, purchaseItemService,
        purchaseTypeFactory, purchaseTypeFilter, warehouseService, stockTypeFactory, stockService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'stockController';
        var localize = abp.localization.getSource('SPMS');

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

        vm.itemGridOptions = {
            enableSorting: true,
            enableRowSelection: true,
            showSelectionCheckbox: true,
            enableSelectAll: false,
            multiSelect: false,
            enableCellEdit: false,
            showGridFooter: true,
            showColumnFooter: true,
            enableFiltering: false,
            columnDefs: [
              { name: 'ItemId', field: 'id' },
              { name: 'PurchaseId', field: 'purchaseId', visible: false },
              { name: 'RawMaterialId', field: 'rawMaterialId', visible: false },
              { name: 'FullProductName', field: 'fullProductName' },
              { name: 'PurchaseQuantity', field: 'purchaseQuantity' },
              { name: 'AvailableQuantiy', field: 'availableQuantiy' }

            ],
            onRegisterApi: function (gridApi) {
                vm.myGridApi = gridApi;
                vm.myGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    vm.disableEdit = false;
                    vm.selectedRowEntity = angular.copy(row.entity);
                });
            }
        };

        vm.getAllPurchaseItems = function () {
            var input = {
                purchaseId: $stateParams.id
            };
            abp.ui.setBusy(
                 null,
                 stockService.getPurchaseItems(input).success(function (data) {
                     vm.purchaseItems = data.purchaseItemStock;
                     vm.itemGridOptions.data = vm.purchaseItems;

                     vm.disableEdit = true;
                 })
             );
        };
        vm.getPurchaseById = function (id) {
            var data = {
                id: id
            };
            abp.ui.setBusy(
                    null,
                    purchaseService.getPurchaseById(data).success(function (data) {

                        vm.purchase = data.purchase;

                    })
                );
        };
        vm.receiveProduct = function () {

            var purchesId = angular.copy(vm.selectedRowEntity.id);
            vm.disableEdit = true;
            $location.path('/stock/add/' + purchesId);
        };
        vm.getWareHouses = function () {
            abp.ui.setBusy(
                    null,
                    warehouseService.getAllWarehouses().success(function (data) {
                        vm.wareHouses = data.warehouses;
                    })
                );
        };

        vm.addToStock = function () {
            if (vm.purchaseItem[0].availableQuantiy <= 0) {
                abp.notify.info('There is no available product to add in stock ', 'No Product');
                return;
            } else if (vm.purchaseItem[0].availableQuantiy < vm.stock.receiveQuantity) {
                abp.notify.info('You try to store more product than avaiable product.', 'No Product');
                return;
            }
            vm.stock.warehouseId = vm.selectedWareHouse.id;
            vm.stock.purchaseItemId = vm.selectedItem.id;
            vm.stock.stockType = vm.selectedStockType.id;
            var data = {
                PurchaseItemId: vm.selectedItem.id
            };
            abp.ui.setBusy(
                   null,
                   stockService.getStocksByPurchaseItem(data).success(function (data) {

                       var stocks = data.stocks;
                       var sumStockedQuantity = 0;
                       angular.forEach(stocks, function (v, k) {
                           sumStockedQuantity = sumStockedQuantity + (parseFloat(v['receiveQuantity']));
                       });
                       var availabeStock = parseFloat(vm.purchaseItem[0].purchaseQuantity) - sumStockedQuantity;

                       if (availabeStock >= vm.stock.receiveQuantity) {
                           stockService.addToStock(vm.stock).success(function () {
                               abp.notify.info(abp.utils.formatString(localize("StockCreateMessage"), vm.purchaseItem[0].fullProductName));

                               vm.stock = {};
                               vm.itemSelectionChange();
                               vm.getAllPurchaseItems();

                           })
                       } else {
                           abp.notify.info('You try to store more product than avaiable product.', 'No Available Product');
                           return;
                       }
                   })

               );
        };

        vm.save = function () {
            vm.addToStock();
        };

        vm.itemSelectionChange = function () {
            if (vm.selectedItem === undefined) {
                vm.disableDensity = true;
                return;
            }
            var expression = {
                id: vm.selectedItem.id
            };
            vm.purchaseItem = $filter('filter')(vm.purchaseItems, expression);
            if (vm.purchaseItem[0].rawMaterialId != '' && vm.purchaseItem[0].rawMaterialTypeCode != 'PKG') {
                vm.disableDensity = false;
                vm.stock.receivedType = 0;
            } else {
                vm.disableDensity = true;

                vm.stock.density = '';
                vm.stock.receivedType = 1;
            }
        };

        vm.stockGridOptions = {
            enableSorting: true,
            enableRowSelection: true,
            showSelectionCheckbox: false,
            enableSelectAll: false,
            multiSelect: false,
            enableCellEdit: false,
            columnDefs: [
              { name: 'SL#', field: 'id', visible: false },
              { name: 'PurchaseItemId', field: 'PurchaseItemId', visible: false },
              { name: 'WarehouseId', field: 'WarehouseId', visible: false },
              { name: 'ProductName', field: 'fullProductName' },
              { name: 'Warehouse', field: 'warehouseName' },
              { name: 'ReceiveQuantity', field: 'receiveQuantity' },
              { name: 'Density', field: 'density' },
              { name: 'TotalQuantity', field: 'totalQuantity' },
              { name: 'ReceivedUnit', field: 'receivedType' },
              { name: 'BinType', field: 'stockType' },
              { name: 'BatchNumber', field: 'batchNumber' },
              { name: 'ReceiveDate', field: 'receiveDate', type: 'date', cellFilter: 'date:"dd-MMM-yyyy "' }
            ],
            onRegisterApi: function (gridApi) {
                vm.myGridApi = gridApi;
                vm.myGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    vm.disableEdit = false;
                    vm.selectedRowEntity = angular.copy(row.entity);
                });
            }
        };

        vm.getStocksByPurchaseId = function (purchaseId) {

            var input = {
                purchaseId: purchaseId
            };
            abp.ui.setBusy(
                 null,
                 stockService.getStocksByPurchase(input).success(function (data) {
                     vm.stocks = data.stocks;
                     vm.stockGridOptions.data = vm.stocks;
                 })
             );
        };

        vm.stockDetails = function () {

            var purchesId = angular.copy(vm.selectedRowEntity.id);
            vm.disableEdit = true;
            $location.path('/stock/details/' + purchesId);
        };
        activate();

        function activate() {
            vm.purchase = {
                id: 0,
                purchaseType: '',
                lcNumber: '',
                lcDate: new Date(),
                poNumber: '',
                poDate: new Date(),
                etd: new Date(),
                eta: new Date(),
                vendorId: '',
                remarks: ''
            };

            vm.purchaseItems = {};
            vm.purchaseItem = {
                id: 0,
                purchaseId: '',
                rawMaterialId: '',
                finishProductId: '',
                rawMaterialTypeCode: '',
                fullProductName: '',
                purchaseQuantity: 0,
                stockQuantiy: 0,
                availableQuantiy: 0
            };
            vm.selectedItem = {
                id: ''
            };

            vm.wareHouses = {};
            vm.selectedWareHouse = {
                id: ''
            };

            vm.stocks = {};
            vm.stock = {
                id: '',
                warehouseId: '',
                purchaseItemId: '',
                receiveQuantity: '',
                density: '',
                totalQuantity: '',
                receivedType: '',
                stockType: '',
                batchNumber: '',
                receiveDate: ''
            }

            vm.stockTypes = stockTypeFactory.getData();
            vm.selectedStockType = {
                id: ''
            };
            vm.disableEdit = true;
            vm.disableDensity = true;

            if ($state.current.data != undefined) {
                if ($state.current.data.action === 'add') {
                    vm.getPurchaseById($stateParams.id);
                    vm.getAllPurchaseItems();
                    vm.getWareHouses();
                }
                else if ($state.current.data.action === 'details') {
                    vm.getStocksByPurchaseId($stateParams.id);
                }
            } else {
                vm.getPurchases();
            }
        }
    }
})();
