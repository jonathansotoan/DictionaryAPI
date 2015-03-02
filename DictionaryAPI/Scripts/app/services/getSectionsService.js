services.factory('getSections', ['$http', 'printHttpError', 'apiUrls', function ($http, printHttpError, apiUrls) {
    return function (callbackFunction) {
        $http.get(apiUrls.sectionsFullUrl).success(callbackFunction).error(printHttpError('Problem while getting the words'));
    };
}]);
