/// <reference path="../module.js" />
/// <reference path="../angular.js" />



(function () {

    'use strict';

    angular

        .module('Enlighten')
        .controller('UserController', UserController);
    UserController.$inject = ['$http'];



    function UserController($http) {

        var vm = this;
        vm.aUser = null;
        vm.UserID = -1;
        vm.AddUpdateUser = AddUpdateUser;

        Activate();

        function Activate() {
            GetUserList();
        }


        function AddUpdateUser() {
            $http.post('User/AddUpdateUser/' + vm.UserID, vm.aUser).then(function (response) {
                vm.aUser = null;
                vm.UserID = -1;
                GetUserList();
                PopupMsg(response.data.message, response.data.type);
               
            });
        }


        //function RemoveCompany(id) {
        //    $http.post('Company/RemoveCompany/' + id).then(function (response) {
        //        vm.aCompany = null;
        //        PopupMsg(response.data.message, response.data.type);
        //        GetCompanyList();
        //    });
        //}



        function GetUserList() {
            $http.post('User/GetUserList').then(function (response) {
                vm.UserList = response.data;
            });
        }


        //function Edit(i) {
        //    vm.CompanyID = i.CompanyID;
        //    vm.aCompany = i;

        //}


        //function ActivateCompany(id) {
        //    $http.post('Company/ActivateCompany/' + id).then(function (response) {
        //        vm.aCompany = null;
        //        PopupMsg(response.data.message, response.data.type);
        //        setTimeout(function () { window.location.href = "Login/Login"; }, 5000);

        //    });
        //}




    }











})();