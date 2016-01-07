(function () {
    'use strict';

    angular
        .module('myApp')

        .value('user', {
            name: 'John Doe',
            server: 'Default'
        });

})();