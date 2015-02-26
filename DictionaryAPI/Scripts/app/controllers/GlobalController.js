controllers.controller('GlobalController', ['saveWord', 'updateWord', function (saveWord, updateWord) {
    // extension methods
    if (!String.prototype.trimHtml) {
        String.prototype.trimHtml = function () {
            return this.replace(/(<\/*p>)+/g, ' ').replace(/\s*(&nbsp;)+\s*/g, ' ').replace(/^\s+|\s+$/g, '');
        }
    }
}]);
