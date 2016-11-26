(function () {
    'use strict';

    angular
        .module('procurement')
        .controller('purchaseController', purchaseController);

    purchaseController.$inject = ['$scope', '$filter', '$location', '$state', '$stateParams', 'appSession', 'abp.services.procurement.purchase', 'abp.services.procurement.purchaseItem',
        'abp.services.app.vendor', 'purchaseTypeFactory', 'abp.services.app.rawMaterial', 'uiGridConstants', 'productTypeFactory', 'abp.services.app.finishProduct', 'productTypeFilter'];

    function purchaseController($scope, $filter, $location, $state, $stateParams, appSession, purchaseService, purchaseItemService,
        vendorService, purchaseTypeFactory, rawMaterialService, uiGridConstants, productTypeFactory, finishProductService, productTypeFilter) {
        var vm = this;
        vm.title = 'Create Purchase';
        var localize = abp.localization.getSource('SPMS');

        vm.gridOptions = {
            enableSorting: true,
            enableRowSelection: true,
            showSelectionCheckbox: true,
            enableSelectAll: false,
            multiSelect: false,
            enableCellEdit: false,
            showGridFooter: true,
            showColumnFooter: true,
            enableFiltering: true,
            columnDefs: [
              { name: 'SL#', field: 'id'},
              { name: 'PurchaseId', field: 'purchaseId', visible: false },
              { name: 'RawMaterialId', field: 'rawMaterialId', visible: false },
              { name: 'FinishProductId', field: 'finishProductId', visible: false },
              { name: 'ProductType', field: 'productType', cellFilter: 'productType' },
              { name: 'FullProductName', field: 'fullProductName' },
              { name: 'PurchaseQuantity', field: 'purchaseQuantity' },
              { name: 'UnitPrice', field: 'unitPrice', cellFilter: 'currency:"Tk. "' },
              {
                  name: 'Amount', field: 'amount', cellFilter: 'currency:"Tk. "', aggregationType: uiGridConstants.aggregationTypes.sum,
                  footerCellFilter: 'currency:"Tk. "'
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

        //vm.dateOptions = {
        //    showAnim: 'slideDown',
        //    changeYear: true,
        //    changeMonth: true,
        //    yearRange: 'c-5:c+5',
        //    currentText: 'Now',
        //    dateFormat: 'dd-M-yy',
        //    minDate: 0,
        //    maxDate: '+10Y',
        //    showButtonPanel: true

        //};

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1,
            minDate: new Date()
        };

        vm.addToGrid = function () {
            vm.purchaseItem.productType = vm.selectedProductType.id;

            if (vm.selectedProductType.id === "0") {
                vm.purchaseItem.rawMaterialId = vm.selectedItem.id;
            } else if (vm.selectedProductType.id === "1") {
                vm.purchaseItem.finishProductId = vm.selectedItem.id;
            }

            vm.purchaseItem.fullProductName = vm.selectedItem.fullProductName;

            vm.purchaseItems.push(angular.copy(vm.purchaseItem));
            vm.purchaseItem.id = vm.purchaseItem.id + 1;
            vm.gridOptions.data = vm.purchaseItems;


            vm.purchaseItem = {
                id: vm.purchaseItem.id,
                purchaseId: '',
                productType: '',
                rawMaterialId: '',
                finishProductId: '',
                purchaseQuantity: '',
                unitPrice: ''
            };
        }

        vm.addNewPurchase = function () {
            vm.purchase.purchaseType = vm.selectedPurchaseType.id;
            vm.purchase.vendorId = vm.selectedVendor.id;

            vm.purchase.purchaseItems = vm.purchaseItems;

            abp.ui.setBusy(
                    null,
                    purchaseService.createPurchase(
                        vm.purchase
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("PurchaseCreatedMessage")));
                        $location.path('/purchase/list');
                    })
                );
        };

        vm.getAllPurchaseItems = function () {
            var input = {
                purchaseId: $stateParams.id,
            };
            abp.ui.setBusy(
                 null,
                 purchaseItemService.getItemsByPurchaseId(input).success(function (data) {
                     angular.forEach(data.purchaseItems, function (item, key) {
                         item.amount = item.purchaseQuantity * item.unitPrice;
                     });
                     vm.gridOptions.data = data.purchaseItems;
                     vm.disableEdit = true;
                 })
             );
        };

        vm.addNewItem = function () {
            vm.purchaseItem.productType = vm.selectedProductType.id;
            if (vm.selectedProductType.id === "0") {
                vm.purchaseItem.rawMaterialId = vm.selectedItem.id;
                vm.purchaseItem.finishProductId = '';
            } else if (vm.selectedProductType.id === "1") {
                vm.purchaseItem.finishProductId = vm.selectedItem.id;
                vm.purchaseItem.rawMaterialId = '';
            }
            
            abp.ui.setBusy(
                   null,
                   purchaseItemService.createPurchaseItem(
                       vm.purchaseItem
                   ).success(function () {
                       abp.notify.info(abp.utils.formatString(localize("PurchaseItemCreatedMessage"), vm.purchaseItem.fullProductName));
                       vm.purchaseItem = {};
                       vm.getAllPurchaseItems();
                       vm.resetItem();
                   })
               );
        };

        vm.updateItem = function () {
            vm.purchaseItem.productType = vm.selectedProductType.id;
            if (vm.selectedProductType.id === "0") {
                vm.purchaseItem.rawMaterialId = vm.selectedItem.id;
                vm.purchaseItem.finishProductId = '';
            } else if (vm.selectedProductType.id === "1") {
                vm.purchaseItem.finishProductId = vm.selectedItem.id;
                vm.purchaseItem.rawMaterialId = '';
            }
            abp.ui.setBusy(
                   null,
                   purchaseItemService.updatePurchaseItem(
                       vm.purchaseItem
                   ).success(function () {
                       abp.notify.info(abp.utils.formatString(localize("PurchaseItemUpdateMessage"), vm.purchaseItem.fullProductName));
                       vm.purchaseItem = {};
                       vm.getAllPurchaseItems();
                   })
               );
        };

        vm.saveItem = function () {
            if (vm.purchaseItem.id === 0 || vm.purchaseItem.id === undefined) {
                vm.purchaseItem.purchaseId = $stateParams.id;
                vm.addNewItem();

            }
            else {
                vm.updateItem();
            }
        };

        vm.deleteItem = function () {
            var data = {
                id: vm.selectedRowEntity.id
            }
            abp.ui.setBusy(
              null,
              purchaseItemService.deletePurchaseItem(
                 data
              ).success(function () {
                  abp.notify.info(abp.utils.formatString(localize("PurchaseItemDeleteMessage"), vm.purchaseItem.fullProductName));
                  vm.getAllPurchaseItems();
              })
          );
        }

        vm.editSelectedRow = function () {
            vm.purchaseItem = vm.selectedRowEntity;
            vm.selectedProductType.id = vm.purchaseItem.productType;
            vm.loadItems();
            if (vm.purchaseItem.productType === 0) {
                vm.selectedItem.id = vm.purchaseItem.rawMaterialId;
            } else {
                vm.selectedItem.id = vm.purchaseItem.finishProductId;
            }
        };

        vm.resetItem = function () {
            vm.purchaseItem = {};
            vm.selectedItem.id = '';
            vm.selectedProductType.id = '';
        };

        vm.updatePurchase = function () {
            vm.purchase.purchaseType = vm.selectedPurchaseType.id;
            vm.purchase.vendorId = vm.selectedVendor.id;

            abp.ui.setBusy(
                    null,
                    purchaseService.updatePurchase(
                        vm.purchase
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("PurchaseUpdateMessage")));
                        $location.path('/purchase/list');
                    })
                );
        };
        vm.getVendors = function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    vendorService.getAllVendors().success(function (data) {
                        vm.vendors = data.vendors;
                    })
                );
        };

        vm.getRawMaterials = function () {
            abp.ui.setBusy(
                    null,
                    rawMaterialService.getAllRawMaterials().success(function (data) {
                        vm.selectedItems = data.rawMaterials;
                    })
                );
        };

        vm.getFinishProducts = function () {
            abp.ui.setBusy(
                    null,
                    finishProductService.getAllFinishProducts().success(function (data) {
                        vm.selectedItems = data.finishProducts;
                    })
                );
        };
        vm.setAmount = function () {
            if (vm.purchaseItem.purchaseQuantity != '' & vm.purchaseItem.unitPrice != '') {
                vm.purchaseItem.amount = vm.purchaseItem.purchaseQuantity * vm.purchaseItem.unitPrice;
            }
        };

        vm.getPurchaseById = function (id) {
            var data = {
                id: id
            };
            abp.ui.setBusy(
                    null,
                    purchaseService.getPurchaseById(data).success(function (data) {

                        vm.purchase = data.purchase;
                        vm.purchase.lcDate = new Date(angular.copy(data.purchase.lcDate));
                        vm.purchase.poDate = new Date(angular.copy(data.purchase.poDate));
                        vm.purchase.etd = new Date(angular.copy(data.purchase.etd));
                        vm.purchase.eta = new Date(angular.copy(data.purchase.eta));


                        vm.selectedPurchaseType.id = vm.purchase.purchaseType;
                        vm.selectedVendor.id = vm.purchase.vendorId;
                        vm.purchaseItems = data.purchaseItems;

                        angular.forEach(vm.purchaseItems, function (item, key) {
                            item.amount = item.purchaseQuantity * item.unitPrice;
                        });


                        vm.gridOptions.data = vm.purchaseItems;
                    })
                );
        };

        vm.open = function ($event, option) {
            if (option === 'lc') {
                vm.status.lcOpened = true;
            }
            else if (option === 'po') {
                vm.status.poOpened = true;
            }
            else if (option === 'etd') {
                vm.status.etdOpened = true;
            }
            else if (option === 'eta') {
                vm.status.etaOpened = true;

            }

        };

        vm.loadItems = function () {
            if (vm.selectedProductType.id === "0" || vm.selectedProductType.id === 0) {
                vm.getRawMaterials();
            } else if (vm.selectedProductType.id === "1" || vm.selectedProductType.id === 1) {
                vm.getFinishProducts();
            } else {
                vm.selectedItems = {};
                vm.selectedItem = {
                    id: ''
                };
            }
        };

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.status = {
                lcOpened: false,
                poOpened: false,
                etdOpened: false,
                etaOpened: false

            };
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
                remarks: '',
                creatorUserId: appSession.user.id
            };
            vm.purchaseItem = {
                id: 0,
                purchaseId: '',
                productType: '',
                rawMaterialId: '',
                finishProductId: '',
                fullProductName: '',
                purchaseQuantity: 0,
                unitPrice: 0,
                amount: 0
            };

            vm.selectedItems = {};
            vm.selectedItem = {
                id: ''
            };
            vm.purchaseItems = [];

            vm.purchaseTypes = purchaseTypeFactory.getData();
            vm.selectedPurchaseType = {
                id: ''
            };

            vm.productTypes = productTypeFactory.getData();
            vm.selectedProductType = {
                id: ''
            };

            vm.vendors = {};
            vm.selectedVendor = {
                id: ''
            };

            vm.getVendors();

            if ($state.current.data != undefined) {
                if ($state.current.data.action === 'edit' || $state.current.data.action === 'detail') {
                    vm.getPurchaseById($stateParams.id);
                }
            }
        }
    }
})();