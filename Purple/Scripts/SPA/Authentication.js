/// <reference path="../angular.min.js" />
var Auth=angular.module("Authentication",[])
.controller('LoginController', function ($scope, $http) {
    $scope.credentials = {
        username: '',
        password: ''
    };

    $http.get('http://localhost:39683/api/Property')

    $scope.login = function (credentials) {
        AuthService.login(credentials).then(function (user) {
            $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
            $scope.setCurrentUser(user);
        }, function () {
            $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
        });
    };
})