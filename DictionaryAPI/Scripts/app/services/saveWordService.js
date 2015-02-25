services.factory('saveWord', ['$http', 'printHttpError', 'apiUrls', function ($http, printHttpError, apiUrls) {
    return function (word, callbackFunction) {
        // returns the assigned id for the word in the back-end
        $http.post(apiUrls.dictionaryFullUrl, word)
            .success(callbackFunction)
            .error(
                printHttpError('Problem while saving the word {"' + word.name + '", "' + word.definition + '"}')
            );
    };
}]);
