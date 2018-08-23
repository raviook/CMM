var ngCMMApp = angular.module("ngCMMApp", []);

ngCMMApp.controller("ngLoginController", ["$scope", "$http", function ($scope, $http) {

    $scope.authentication = function () {
        $scope.isuserValidmsg = false;
        $http({
            method:'POST',
            url:'/Home/Login',
            data: 'formData=' + JSON.stringify($scope.login),
            headers: {'Content-Type': 'application/x-www-form-urlencoded'}
        }
            ).then(function (response) {
                if (response.data === 'null') {
                    $scope.isuserValidmsg = true;
                }
                else {
                    window.location.href = "/Dashboard/index";
                }
        });
        
    }

}])