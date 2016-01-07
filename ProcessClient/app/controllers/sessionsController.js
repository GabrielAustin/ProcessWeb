(function () {
    'use strict';

    angular
        .module('myApp')
        .controller('SessionsController', SessionsController);

    SessionsController.$inject = ['processEngine', 'user','$state'];

    function SessionsController(processEngine, user, $state) {
        var vm = this;

        vm.title = "Login"
        vm.user = { name: "", pass: "", envi: user.server };
        vm.isLogged = processEngine.isLogged;
        vm.login = login;
        vm.loginRecover = loginRecover;
        vm.loginRenew = loginRenew;
        vm.logout = logout;
        vm.response = {};


        function login() {
            processEngine.postSession(vm.user)
                .then(function (data) {
                    if (data.message === "15140") {
                        alert('Already Signed in!')
                        vm.isLogged = true;
                    } else {
                        alert('Signed in!')
                        user.name = vm.user.name;
                        user.pass = vm.user.pass;
                        $state.go('root.tasks');
                    }
                    vm.response = data;
                    return vm.response;
                });
        }

        function loginRecover() {
            processEngine.getSession(vm.user)
                .then(function (data) {
                    vm.response = data;
                    user.name = vm.user.name;
                    user.pass = vm.user.pass;
                    $state.go('root.tasks');
                    return vm.response;
                })
        }

        function loginRenew() {
            processEngine.putSession(vm.user)
                .then(function (data) {
                    vm.response = data
                    user.name = vm.user.name;
                    user.pass = vm.user.pass;
                    $state.go('root.tasks')
                    return vm.response;
                })
        }

        function logout() {
            processEngine.deleteSession()
                .then(function (data) {
                    alert('Signed out!');
                    vm.response = data;
                    $state.go('environments')
                    return vm.response;
                })
        }

    }
})();