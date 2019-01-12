/// <reference path="../module.js" />
/// <reference path="../angular.js" />



(function () {

    'use strict';



    angular

        .module('Enlighten')

        .controller('CompanyController', CompanyController);



    CompanyController.$inject = ['$http'];



    function CompanyController($http) {

        var vm = this;
        vm.AddUpdateCompany = AddUpdateCompany;
        vm.GetCompanyList = GetCompanyList;
        vm.aCompany;
        vm.message;
        vm.cls;
        vm.CompanyList = [];
        //function getname() {
        //    $http.get('Home/test')
        //    .then(function (response) {
        //        window.location.href = response.data;
        //    });
        //}

        Activate();

        function Activate()
        {
            GetCompanyList();
        }

        function AddUpdateCompany()
        {
            $http.post('/Company/AddUpdateCompany',vm.aCompany).then(function (response) {
                vm.message = response.data.message;
                vm.cls = response.data.cls;
                GetCompanyList();
            });
        }


        function GetCompanyList() {
            $http.post('/Company/GetCompanyList').then(function (response) {
                vm.CompanyList = response.data.list;
            });
        }

      

    }











})();