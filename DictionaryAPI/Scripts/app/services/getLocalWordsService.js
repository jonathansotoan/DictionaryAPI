services.service('getLocalWords', [function () {
    var words;

    return {
        get: function () {
            return words;
        },
        set: function (newWords) {
            words = newWords;
        }
    };
}]);
