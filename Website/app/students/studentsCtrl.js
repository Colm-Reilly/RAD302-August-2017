(function () {
    "use strict";
    angular
        .module("studentManagement")
        .controller("studentsCtrl",
                     ["studentResource",
                         studentsCtrl]);

    function studentsCtrl(studentResource) {
        var vm = this;

        studentResource.query(function (data) {
            vm.students = data;
        });
    }
}());
