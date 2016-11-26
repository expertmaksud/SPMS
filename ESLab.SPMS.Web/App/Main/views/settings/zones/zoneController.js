(function () {
    'use strict';

    angular
        .module('main')
        .controller('zoneController', zoneController);    

    zoneController.$inject = ['$scope', '$location', 'appSession', 'abp.services.app.zone'];   

    function zoneController($scope, $location, appSession, zoneService) {    
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Zone';
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
              { name: 'ZoneCode', field: 'zoneCode' },
              { name: 'ZoneName', field: 'zoneName' },
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


        vm.addNewZone = function () {                           //full function need to check
            abp.ui.setBusy(
                    null,
                    zoneService.createZone(
                        vm.zone
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ZoneCreatedMessage"), vm.zone.zoneName));
                        activate();

                    })
                );
        };
        vm.deleteZone = function () {                           //full function need to check
            abp.ui.setBusy(
                    null,
                    zoneService.deleteZone(
                    vm.selectedRowEntity
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ZoneDeletedMessage"), vm.zone.zoneName));
                        activate();

                    })
                );
        };

        vm.getZones = function () {
            abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    zoneService.getAllZones().success(function (data) {
                        vm.gridOptions.data = data.zones;
                    })
                );
        };

        vm.editSelectedRow = function () {
            vm.zone = vm.selectedRowEntity;
        }

        vm.updateZone = function () {
            abp.ui.setBusy(
                    null,
                    zoneService.updateZone(
                        vm.zone
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("ZoneUpdatedMessage"), vm.zone.zoneName));
                        activate();
                        //$location.path('/zoness');
                    })
                );
        };

        vm.saveZone = function () {           //
            if (vm.zone.id != 0) {
                vm.updateZone();
            }
            else {
                vm.addNewZone();
            }

        }

        activate();

        function activate() {
            vm.disableEdit = true;
            vm.zone = {
                id: 0,
                zoneCode: '',
                zoneName: '',
                creatorUserId: appSession.user.id
            };
            vm.getZones();
        }
    }
})();