

ngCMMApp.controller("ngDashboardController", ["$scope", "$http", function ($scope, $http, FileUploadService) {
    $scope.form1 = true;
    $scope.form2 = false;
    $scope.membershipType = ['Members', 'Excol Members']; 
    $scope.ngappMessage = 'ng of Dashboard is working';
    $scope.member = { showOnHomePage: false };
    $scope.createMember = function () {
        $http({
            method: 'POST',
            url: '/Dashboard/CreateMember',
            data: 'memberDetails=' + JSON.stringify($scope.member),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(function (response) {
            alert(response.data);
        },
function (response) {
    alert('false');
});
    }

}]);

ngCMMApp.directive('validFile', [function () {
    return {
        require: 'ngModel',
        scope: { format: '@', upload: '&upload' },
        link: function (scope, el, attrs, ngModel) {
            // change event is fired when file is selected
            el.bind('change', function (event) {
                scope.upload({ file: event.target.files[0] });
                scope.$apply(function () {
                    ngModel.$setViewValue(el.val());
                    ngModel.$render();
                });
            })
        }
    }
}]);

