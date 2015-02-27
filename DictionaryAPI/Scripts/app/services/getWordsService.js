services.factory('getWords', ['$http', 'printHttpError', 'apiUrls', function ($http, printHttpError, apiUrls) {
    return function (callbackFunction) {
        $http.get(apiUrls.wordsFullUrl).success(callbackFunction).error(printHttpError('Problem while getting the words'));
    };
}]);
