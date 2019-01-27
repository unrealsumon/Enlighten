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
        vm.eUser = null;
        vm.aUser = null;
        vm.UserID = -1;
        vm.UpdateUser = UpdateUser;
        vm.AddUser = AddUser;
        vm.Edit = Edit;
        vm.RemoveUser = RemoveUser;
        Activate();

        function Activate() {
            GetUserList();
        }


        function UpdateUser() {
            $http.post('User/UpdateUser/' + vm.UserID, vm.eUser).then(function (response) {
                vm.eUser = null;
                vm.UserID = -1;
                GetUserList();
                PopupMsg(response.data.message, response.data.type);
               
            });
        }


        function AddUser() {
            $http.post('User/AddUser/' , vm.aUser).then(function (response) {
                vm.aUser = null;
                vm.UserID = -1;
                GetUserList();
                PopupMsg(response.data.message, response.data.type);

            });
        }


        function RemoveUser(id) {
            $http.post('User/RemoveUser/' + id).then(function (response) {
                vm.aUser = null;
                vm.eUser = null;
                GetUserList();
                PopupMsg(response.data.message, response.data.type);
              
            });
        }



        function GetUserList() {
            $http.post('User/GetUserList').then(function (response) {
                vm.UserList = response.data.list;
                vm.IsMaster = response.data.IsMaster;
            });
        }


        function Edit(i) {
            vm.eUser = i;
            vm.UserID = i.UserID;

        }


        //function ActivateCompany(id) {
        //    $http.post('Company/ActivateCompany/' + id).then(function (response) {
        //        vm.aCompany = null;
        //        PopupMsg(response.data.message, response.data.type);
        //        setTimeout(function () { window.location.href = "Login/Login"; }, 5000);

        //    });
        //}




    }











})();