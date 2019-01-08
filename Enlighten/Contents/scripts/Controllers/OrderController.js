/// <reference path="../module.js" />
/// <reference path="../angular.js" />



(function () {

    'use strict';



    angular

        .module('app')

        .controller('OrderController', OrderController);



    OrderController.$inject = ['$http'];



    function OrderController($http) {

        var vm = this;
        vm.getname = getname;
        vm.holla = Holla;

        function getname() {
            $http.get('Home/test')
            .then(function (response) {
                window.location.href =response.data;
            });
        }


        function Holla()
        {
            window.alert("HOllaa");
        }


        }

    









})();