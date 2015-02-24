services.factory('updateWord', ['$http', 'printHttpError', 'apiUrls', function ($http, printHttpError, apiUrls) {
    return function (word) {
        $http.put(apiUrls.wordsFullUrl, word).success(function () {
            console.log('word {' + word.id + ', "' + word.name + '", "' + word.definition + '"} updated');
        }).error(printHttpError);
    };
}]);
