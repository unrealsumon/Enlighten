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
        vm.Edit = Edit;
        vm.aCompany;
        vm.message;
        vm.cls;
        vm.CompanyList = [];
        vm.CompanyID = -1;
      
      

        Activate();

        function Activate()
        {
            GetCompanyList();
        }

        function AddUpdateCompany()
        {
            $http.post(rootUrl+"/Company/AddUpdateCompany/" + vm.CompanyID, vm.aCompany).then(function (response) {
                vm.aCompany = null;
                vm.CompanyID = -1;
                PopupMsg(response.data.message,response.data.type);
             
             
               GetCompanyList();
            });
        }


        function RemoveCompany(id) {
           
            $http.post(rootUrl+ "/Company/RemoveCompany/" + id).then(function (response) {
                vm.aCompany = null;

                PopupMsg(response.data.message, response.data.type);

                GetCompanyList();
            });
        }
                  
            
      
        function GetCompanyList() {
            $http.post(rootUrl+'/Company/GetCompanyList').then(function (response) {
                vm.CompanyList = response.data.list;
            });
        }


        function Edit(i) {

            
            //var c =vm.CompanyList[i];

            //var CompanyToEdit=
            //    {
            //        CompanyID:c.CompanyID,
            //        CompanyName: c.CompanyName,
            //        Address: c.Address,
            //        Email: c.Email,
            //        Phone: c.Phone,
            //        HeaderInfoFirst: c.HeaderInfoFirst,
            //        HeaderInfoSecond: c.HeaderInfoSecond,
            //        HeaderInfoThird: c.HeaderInfoThird,
            //        FooterInfoFirst: c.FooterInfoFirst,
            //        FooterInfoSecond:c.FooterInfoSecond               
            //    }
            vm.CompanyID = i.CompanyID;
            vm.aCompany = i;
         
       
        }



      
      

    }











})();