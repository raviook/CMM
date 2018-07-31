var ngCMMApp = angular.module("ngCMMApp", []);

ngCMMApp.controller("ngDemoController", ["$scope", "$http", function ($scope, $http) {

    $scope.ngappMessage = 'ng is working';
    $http.get('/Demo/demoList').then(function (response) {
        $scope.demoList = response.data;
    });

}])
