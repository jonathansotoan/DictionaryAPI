services.factory('apiUrls', [function () {
    var apiUrl = 'http://localhost:55451/';
    var wordsRelativeUrl = 'api/Words/';

    return {
        apiUrl: apiUrl,
        wordsRelativeUrl: wordsRelativeUrl,
        wordsFullUrl: apiUrl + wordsRelativeUrl
    };
}]);
