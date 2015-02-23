services.factory('getWords', ['$http', 'printHttpError', 'apiUrls', function ($http, printHttpError, apiUrls) {
    return function () {
        $http.get(apiUrls.dictionaryFullUrl).success(function (returnedWords) {
            console.log('loaded');
            return returnedWords;
        }).error(printHttpError);
    };
}]);
