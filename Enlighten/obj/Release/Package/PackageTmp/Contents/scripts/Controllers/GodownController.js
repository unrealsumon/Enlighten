/// <reference path="../module.js" />
/// <reference path="../angular.js" />



(function () {

    'use strict';

    angular

        .module('Enlighten')
        .controller('GodownController', GodownController);
    GodownController.$inject = ['$http'];



    function GodownController($http) {

        var vm = this;
        vm.aCategory = null;
        vm.aProduct = null;
        vm.GodownID = -1;
        vm.CategoryID = -1;
        vm.AddUpdateGodown = AddUpdateGodown;
        vm.AddUpdateCategory = AddUpdateCategory;
        vm.RemoveGodown = RemoveGodown;
        vm.Edit = Edit;
        vm.EditCategory = EditCategory;
        vm.ToggleTab = ToggleTab;
        vm.RemoveProduct = RemoveProduct;
        vm.tab1 = "active";
        vm.tab2 = "";
        vm.tab3 = "";
        //vm.CategoryList = [{ model: "Ford Mustang", color: "red" },
        //{ model: "Fiat 500", color: "white" },
        //{ model: "Volvo XC90", color: "black" }];
        vm.CategoryList = {};
        Activate();

        function Activate() {
            GetGodownList();
       
        }


        function AddUpdateGodown() {

            $http.post('Godown/AddUpdateGodown/' + vm.GodownID, vm.aGodown).then(function (response) {
                vm.aGodown= null;
                vm.GodownID= -1;
                GetGodownList();
                PopupMsg(response.data.message, response.data.type);

            });
        }

        function AddUpdateCategory() {

            $http.post('Product/AddUpdateCategory/' + vm.CategoryID, vm.aCategory).then(function (response) {
                vm.aCategory = null;
                vm.CategoryID = -1;
                GetCategoryList();
                PopupMsg(response.data.message, response.data.type);

            });
        }


        function RemoveProduct() {
            $http.post('Product/RemoveProduct/' + vm.ProductID).then(function (response) {
                vm.aProduct = null;
                vm.ProductID = -1;
                GetProductList();
                PopupMsg(response.data.message, response.data.type);

            });
        }


        function RemoveGodown() {
            $http.post('Godown/RemoveGodown/' + vm.GodownID).then(function (response) {
                vm.aGodown = null;
                vm.GodownID = -1;
                GetGodownList();
                PopupMsg(response.data.message, response.data.type);

            });
        }

        function GetGodownList() {
            $http.post('Godown/GetGodownList').then(function (response) {
                vm.GodownList = response.data.list;
                vm.IsMaster = response.data.IsMaster;
            });
        }

        function GetCategoryList() {
            $http.post('Product/GetCategoryList').then(function (response) {
                vm.CategoryList = response.data.list;

            });
        }

        function Edit(i) {
            vm.aGodown = i;
            vm.GodownID = i.GodownID;
     
       

        }

        function EditCategory(i) {
            vm.aCategory = i;
            vm.CategoryID = i.CategoryID;
            vm.ProductID = -1;
            vm.aProduct = null;
            ToggleTab(2);

        }

        function ToggleTab(n) {
            if (n == 1) {
                vm.tab1 = "active";
                vm.tab2 = "";
                vm.tab3 = "";
            }
            else if (n == 2) {
                vm.tab1 = "";
                vm.tab2 = "active";
                vm.tab3 = "";
            }
            else if (n == 3) {
                vm.tab1 = "";
                vm.tab2 = "";
                vm.tab3 = "active";
            }
        }







    }











})();