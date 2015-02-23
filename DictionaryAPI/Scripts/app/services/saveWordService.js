services.factory('saveWord', ['$http', 'printHttpError', 'apiUrls', function ($http, printHttpError, apiUrls) {
    return function (word) {
        $http.post(apiUrls.dictionaryFullUrl, word).success(function () {
            console.log('word {"' + word.name + '", "' + word.definition + '"} created');
        }).error(printHttpError);
    };
}]);
