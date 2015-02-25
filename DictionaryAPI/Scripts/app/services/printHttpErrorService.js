services.service('printHttpError', [function () {
    return function(message) {
        return function (jqXHR, textStatus, errorThrown) {
            var errorObj = {
                jqXHR: jqXHR,
                textStatus: textStatus,
                errorThrown: errorThrown.toString()
            };
            console.error('Something went wrong: "' + message + '." See below for details');
            console.log(errorObj);//in a single line for easier debug on consoles like the chrome's one
        };
    }
}]);
