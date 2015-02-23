controllers.controller('GlobalController', ['saveWord', 'updateWord', function (saveWord, updateWord) {
    // extension methods
    if (!String.prototype.trim) {
        String.prototype.trim = function () {
            return this.replace(/^\s+|\s+$/g, '');
        }
    }
}]);
