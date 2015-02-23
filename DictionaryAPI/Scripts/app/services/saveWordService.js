services.factory('saveWord', ['$http', 'printHttpError', 'apiUrls', function ($http, printHttpError, apiUrls) {
    return function (word, callbackFunction) {
        $http.post(apiUrls.dictionaryFullUrl, word).success(function (returnedId) {
            callbackFunction(returnedId);
            console.log('word {"' + word.name + '", "' + word.definition + '"} created');
        }).error(printHttpError);
    };
}]);
