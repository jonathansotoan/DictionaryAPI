services.factory('apiUrls', [function () {
    var apiUrl = 'http://localhost:55451/';
    var wordsRelativeUrl = 'api/Words/';
    var sectionsRelativeUrl = 'api/Sections/';

    return {
        apiUrl: apiUrl,
        wordsRelativeUrl: wordsRelativeUrl,
        wordsFullUrl: apiUrl + wordsRelativeUrl,
        sectionsRelativeUrl: sectionsRelativeUrl,
        sectionsFullUrl: apiUrl + sectionsRelativeUrl
    };
}]);
