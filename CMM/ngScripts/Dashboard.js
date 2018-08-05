

ngCMMApp.controller("ngDashboardController", ["$scope", "$http", function ($scope, $http) {

    $scope.ngappMessage = 'ng of Dashboard is working';
    $http.get('/Demo/demoList').then(function (response) {
        $scope.demoList = response.data;
    });

}])