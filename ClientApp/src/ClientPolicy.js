let purchaseApp = angular.module("purchaseApp", []);

purchaseApp.controller("purchaseController", function ($scope, $http) {

  $scope.filter = "";
  $scope.number = "";
  $scope.fullName = "";

  $scope.GetListInsurancePolicies = async function () {
    await $http.get('/InsurancePolicy')
      .then((result) => {
        $scope.list = result.data;
        $scope.setFilter();
      });
  }

  $scope.addItem = async function (number, fullName) {

    let policy = {
      Number: number,
      FullName: fullName
    };

    await $http.post('/InsurancePolicy', policy);

    $scope.GetListInsurancePolicies();

  }

  $scope.deleteItem = async function (item) {

    let id = item.id;

    await $http.delete('/InsurancePolicy/' + id, id)

    $scope.GetListInsurancePolicies();

  }

  $scope.changeItem = function (item) {
    var dialog = document.getElementById('window');

    $scope.dialogNumber = item.number;
    $scope.dialogDateOfCreation = item.dateOfCreation;
    $scope.dialogFullName = item.fullName;

    $scope.dialogItem = item;

    dialog.show();

  }

  $scope.dialogChangeItem = async function () {
    var dialog = document.getElementById('window');

    let policy = {
      Id: $scope.dialogItem.id,
      Number: $scope.dialogNumber,
      DateOfCreation: $scope.dialogDateOfCreation,
      FullName: $scope.dialogFullName
    };

    await $http.put('/InsurancePolicy', policy);

    $scope.GetListInsurancePolicies();

    await dialog.close();
  }

  $scope.dialogExit = function () {

    var dialog = document.getElementById('window');

    dialog.close();

  }

  $scope.setFilter = function () {

    let filter = $scope.filter;
    $scope.filterList = $scope.list.filter((policy) => policy.number.includes(filter) || policy.dateOfCreation.includes(filter) || policy.fullName.includes(filter));

  }

});
