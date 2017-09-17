//Though AngularJS controllers can call directly into back- end services,
//    If we put that type of functionality into factories, it can be more re- useable and easier to maintain.
//(In this module I have used only GET method)
var MyApp = angular.module('empApp', [])
    .factory('dataFactory', ['$http', function ($http) {
        //The $http object is injected into the factory at runtime by AngularJS and used to make Ajax calls to the server. (Dependency Injection)
        //Angular JS itself has a built-in dependency injection
        var urlBase = 'http://localhost:64810/api/employeeapi';
        var dataFactory = {};
        dataFactory.getEmployees = function () {
            return $http.get(urlBase);
        };
        dataFactory.insertEmployee = function (emp) {
            return $http.post(urlBase, emp);
        };
        dataFactory.updateEmployee = function (emp) {
            return $http.put(urlBase + '/' + emp.SNo, emp)
        };
        dataFactory.deleteEmployee = function (SNo) {
            return $http.delete(urlBase + '/' + SNo);
        };

        return dataFactory;
    }]);

//Creating the Controller
MyApp
    .controller('empController', ['$scope', 'dataFactory',
        function ($scope, dataFactory) {
            
            $scope.status;
            $scope.employees;
            getEmployees();
            function getEmployees() {
                dataFactory.getEmployees().then(function (response)
                { $scope.employees = response.data; }, function (error) {
                    $scope.status = 'Unable to load Employee data: ' + error.message;
                });
            }       

           

        }]);
