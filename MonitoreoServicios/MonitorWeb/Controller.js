var app = angular.module("myApp", []);

app.controller("myCtrl", function ($scope) {

    $scope.conn = $.connection.monitorHub;
    $scope.estados;
    //Funcion js Request ESTADOS
    $scope.requestEstados = function () {
        $.connection.hub.start().done(function () {
            $scope.conn.server.requestMostrarEstados();
        });
    };
    //Funcion js Callback ESTADOS
    $scope.conn.client.callbackEstados = function (estados) {
        var response = angular.fromJson(estados);
        var artists = response.AlarmaObjeto;
        $scope.estados = artists;
        $scope.$digest();
        console.log(artists);
    };
    $scope.requestEstados();
    //INICIO ESTAPA ESTADOS DE SERVICIOS
    $scope.iniciarServicio = function (service) {
        $.connection.hub.start().done(function () {
            $scope.conn.server.requestIniciarServicio(service);
        });
    };
    $scope.detenerServicio = function (service) {
        $.connection.hub.start().done(function () {
            $scope.conn.server.requestDetenerServicio(service);
        });
    };
    $scope.pausarServicio = function (service) {
        $.connection.hub.start().done(function () {
            $scope.conn.server.requestPausarServicio(service);
        });
    };
    $scope.reanudarServicio = function (service) {
        $.connection.hub.start().done(function () {
            $scope.conn.server.requestReanudarServicio(service);
        });
    };
    $scope.reiniciarServicio = function (service) {
        $.connection.hub.start().done(function () {
            $scope.conn.server.requestReiniciarServicio(service);
        });
    };
    $scope.killService = function (PID) {
        $.connection.hub.start().done(function () {
            $scope.conn.server.requestkillService(PID);
        });
    };
});