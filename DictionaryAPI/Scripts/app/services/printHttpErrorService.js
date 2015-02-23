services.factory('printHttpError', [function () {
    return function (jqXHR, textStatus, errorThrown) {
        console.log('something went wrong:');
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
    };
}]);