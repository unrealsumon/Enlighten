/// <reference path="../module.js" />
/// <reference path="../angular.js" />



(function () {

    'use strict';

    angular

        .module('Enlighten')
        .controller('ProductController', productController);
    productController.$inject = ['$http'];



    function productController($http) {

        var vm = this;
        vm.aCategory = null;
        vm.aProduct = null;
        vm.ProductID = -1;  
        vm.AddUpdateProduct = AddUpdateProduct;
        vm.Edit = Edit;
        vm.RemoveProduct = RemoveProduct;
        Activate();

        function Activate() {
            GetProductList();
        }


        function AddUpdateProduct() {
            $http.post('Product/AddUpdateProduct/' + vm.ProductID, vm.aProduct).then(function (response) {
                vm.aProduct = null;
                vm.ProductID = -1;
                GetProductList();
                PopupMsg(response.data.message, response.data.type);

            });
        }




        function RemoveProduct(id) {
            $http.post('Product/RemoveProduct/' + id).then(function (response) {
                vm.aProduct = null;
                vm.ProductID = -1;
                GetProductList();
                PopupMsg(response.data.message, response.data.type);

            });
        }



        function GetProductList() {
            $http.post('Product/GetProductList').then(function (response) {
                vm.ProductList = response.data.list;
                vm.IsMaster = response.data.IsMaster;
            });
        }


        function Edit(i) {
            vm.aProduct = i;
            vm.ProductID = i.ProductID;

        }


      




    }











})();