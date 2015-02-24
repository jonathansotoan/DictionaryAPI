services.factory('saveWord', ['$http', 'printHttpError', 'apiUrls', function ($http, printHttpError, apiUrls) {
    return function (word, callbackFunction) {
        $http.post(apiUrls.wordsFullUrl, word).success(function (returnedId) {
            callbackFunction(returnedId);
            console.log('word {"' + word.name + '", "' + word.definition + '"} created');
        }).error(printHttpError);
    };
}]);
