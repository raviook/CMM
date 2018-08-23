

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
            $scope.form1 = false;
            $scope.form2 = true;
            $scope.membershipId = response.data;
        },
function (response) {
    alert('Something went wrong Please try again!');
});
    }

    $scope.uploadProfilePic = function (element) {
        var formData = new FormData();
        formData.append("uploadedFile", element);
        formData.append("memberId", $scope.membershipId);
        $http({
            method: 'POST',
            url: '/Dashboard/ProfilePicUploader',
            data: formData,
            headers: {
                'Content-Type': undefined
            }
        }).then(function (response) {
            $scope.attachmentPath = response.data;
            if (response.data == $scope.membershipId) {
                $scope.isPicUploaded = true;
            }
        },
            function () {
                alert('something going wrong while uploading');
            });

    }
    $scope.uploadFile = function (element) {
        var formData = new FormData();
        formData.append("uploadedFile", element);
        formData.append("memberId", $scope.membershipId);
        $http({
            method: 'POST',
            url: '/Dashboard/MemberDocumentUploader',
            data: formData,
            headers: {
                'Content-Type': undefined
            }
        }).then(function (response) {
            if (response.data == $scope.membershipId) {
                $scope.isFileUploaded = true;
            }
        },
            function () {
                alert('something going wrong while uploading');
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

