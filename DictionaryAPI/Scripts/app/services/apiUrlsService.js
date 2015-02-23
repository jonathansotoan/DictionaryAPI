services.factory('apiUrls', [function () {
    var apiUrl = 'http://localhost:55451/';
    var dictionaryRelativeUrl = 'api/Dictionary/';

    return {
        apiUrl: apiUrl,
        dictionaryRelativeUrl: dictionaryRelativeUrl,
        dictionaryFullUrl: apiUrl + dictionaryRelativeUrl
    };
}]);
