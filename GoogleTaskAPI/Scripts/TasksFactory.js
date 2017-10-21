
var serviceId = 'TasksFactory';
angular.module('GoogleTasks').factory(serviceId,
    ['$http', TasksFactory]);

function TasksFactory($http) {

    function getTaskLists() {



        return $http.get('/api/defaultTasklist');
    }

    function getAllTasks() {

        return $http.get('/api/task/AllTasks');
    }



    function deleteTask(id) {

        return $http.delete('/api/task/DeletedTask/'+id );
    }


    function deleteAllTasks() {

        return $http.delete('/api/task/ClearAllTasks');
    }


    function insertTask(_title, _note) {

        var data = { title: _title, note: _note };
        return $http.post('/api/task/InsertTask', data);
    }


    var service = {
        insertTask: insertTask,
        deleteAllTasks: deleteAllTasks,
        deleteTask: deleteTask,
        getAllTasks: getAllTasks,
        getTaskLists: getTaskLists
    };

    return service;
}