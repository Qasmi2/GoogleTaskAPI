
var controllerId = 'mainController';
angular.module('GoogleTasks').controller(controllerId,
    ['$scope', 'TasksFactory', mainController]);



function mainController($scope, TasksFactory) {

    $scope.message = "Hello world";
    $scope.disabled = false;

    TasksFactory.getTaskLists().then(
        // callback function for successful http request
        function success(response) {

            $scope.tasklist = response.data;
        },
        // callback function for error in http request
        function error(response) {
            // log errors
        }
    );
    TasksFactory.getAllTasks().then(
        // callback function for successful http request
        function success(response) {

            $scope.allTasks = response.data;
        },
        // callback function for error in http request
        function error(response) {
            // log errors
        }
    );
    $scope.delete_Task = function()
    {
        TasksFactory.deleteTask(this.task.id).then(
        // callback function for successful http request
        function success(response) {

            $scope.message = response.data;


            TasksFactory.getAllTasks().then(
            // callback function for successful http request
            function success(response) {

                $scope.allTasks = response.data;
            },
            // callback function for error in http request
            function error(response) {
                // log errors
            }
        );
        },
        // callback function for error in http request
        function error(response) {
            // log errors
            $scope.message = 'error deleting task';
        }
        );
    }


    $scope.delete_All_Task = function () {
        TasksFactory.deleteAllTasks().then(
        // callback function for successful http request
        function success(response) {

            $scope.message = response.data;


            TasksFactory.getAllTasks().then(
            // callback function for successful http request
            function success(response) {

                $scope.allTasks = response.data;
            },
            // callback function for error in http request
            function error(response) {
                // log errors
            }
        );
        },
        // callback function for error in http request
        function error(response) {
            // log errors
            $scope.message = 'error deleting task';
        }
        );
    }


    $scope.insert_task = function () {

        TasksFactory.insertTask($scope.title,$scope.note).then(
        // callback function for successful http request
        function success(response) {

            $scope.message = response.data;

            $scope.disabled = !($scope.disabled);

            $scope.title = '';
            $scope.note= '';
            TasksFactory.getAllTasks().then(
            // callback function for successful http request
            function success(response) {

                $scope.allTasks = response.data;
            },
            // callback function for error in http request
            function error(response) {
                // log errors
            }
        );
        },
        // callback function for error in http request
        function error(response) {
            // log errors
            $scope.message = 'error deleting task';
        }
        );
    }

}

