services.factory('deleteWord', ['$http', 'printHttpError', 'apiUrls', function ($http, printHttpError, apiUrls) {
    return function (id, callbackFunction) {
        $http.delete(apiUrls.dictionaryFullUrl + id).success(callbackFunction).error(
            printHttpError('Problem while trying to delete the word with id' + id)
        );
    };
}]);
