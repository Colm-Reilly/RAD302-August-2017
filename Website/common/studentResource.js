(function () {
    "use strict"

    angular
    .module("common.services")
    .factory("studentResource",
    ["$resource",
        "appSettings",
        studentResource])


    function studentResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/students/");
    }
});