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
        vm.RemoveCompany = RemoveCompany;
        vm.GetCompanyList = GetCompanyList;
        vm.ActivateCompany = ActivateCompany;
        vm.Edit = Edit;
        vm.aCompany;
        vm.message;
        vm.cls;
        vm.CompanyList = [];
        vm.CompanyID = -1;



        Activate();


        function Activate(){
            GetCompanyList();
        }


        function AddUpdateCompany(){
                $http.post('Company/AddUpdateCompany/' + vm.CompanyID, vm.aCompany).then(function (response) {
                vm.aCompany = null;
                vm.CompanyID = -1;
                PopupMsg(response.data.message,response.data.type);               
                GetCompanyList();
            });
        }


        function RemoveCompany(id){           
                $http.post('Company/RemoveCompany/' + id).then(function (response) {
                vm.aCompany = null;
                PopupMsg(response.data.message, response.data.type);
                GetCompanyList();
            });
        }
                  
            
      
        function GetCompanyList() {
                $http.post('Company/GetCompanies').then(function (response) {
                    vm.CompanyList = response.data.list;
                    vm.IsMaster = response.data.IsMaster;
            });
        }


        function Edit(i) {
            vm.CompanyID = i.CompanyID;
            vm.aCompany = i;        
       
        }


        function ActivateCompany(id){           
                $http.post('Company/ActivateCompany/' + id).then(function (response) {
                    vm.aCompany = null;
                    PopupMsg(response.data.message, response.data.type);
                    //setTimeout(function () { window.location.href = "Login/Login"; }, 5000);
                   
                });
            }

      
      

    }











})();