services.factory('apiUrls', [function () {
    var apiUrl = 'http://localhost:55451/api/';
    var wordsRelativeUrl = 'Words/';

    return {
        apiUrl: apiUrl,
        wordsRelativeUrl: wordsRelativeUrl,
        wordsFullUrl: apiUrl + wordsRelativeUrl
    };
}]);
