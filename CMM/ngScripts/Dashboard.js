

ngCMMApp.controller("ngDashboardController", ["$scope", "$http", function ($scope, $http) {

    $scope.membershipType = {
        availableOptions: [
            { id: '1', name: 'TypeA' },
            { id: '2', name: 'TypeB' }
        ],
        selectedOption: { id: '1', name: 'TypeA' }
    };
    $scope.uploadImage = function (element) {
        conaole.log(element);
        var formData = new FormData();
        formData.append("uploadedFile", element);
        $http({
            method: 'POST',
            url: '',
            data: formData,
            headers: {
                'Content-Type': undefined
            }
        }).then(function (response) {
            $scope.attachmentPath = response.data;
            console.log(response.data);
        },
            function () {
                alert('something going wrong while uploading');
            });

    }

    $scope.uploadFile = function (element) {
        conaole.log(element);
        var formData = new FormData();
        formData.append("uploadedFile", element);
        $http({
            method: 'POST',
            url: '',
            data: formData,
            headers: {
                'Content-Type': undefined
            }
        }).then(function (response) {
            $scope.attachmentPath = response.data;
            console.log(response.data);
        },
            function () {
                alert('something going wrong while uploading');
            });

    }
    $scope.ngappMessage = 'ng of Dashboard is working';
    $scope.member = { showOnHomePage: false };
    $scope.createMember = function () {
        var gh = $scope.member;
        console.log(gh);
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