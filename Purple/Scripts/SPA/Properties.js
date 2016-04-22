/// <reference path="../angular.min.js" />

var Properties = angular.module('PropertiesModule', [])
                        .controller('PropertiesController', function ($scope, $http) {
                            $http.get("http://localhost:39683/api/Property")
                            .then(function (response) {
                                $scope.PropertyList = response.data;
                            });
                        });
