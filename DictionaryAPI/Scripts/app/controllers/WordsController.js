controllers.controller('WordsController', ['getWords', 'deleteWord', function (getWords, deleteWord) {
    this.words = getWords();

    this.addWord = function () {
        this.words[this.words.length] = {
            name: 'WordToDefine',
            definition: 'Write your definition here'
        };
    };

    this.deleteWord = function (id) {
        deleteWord(id, function () {
            var wordToDelete = this.words.filter(function (wordItem) {
                return wordItem.id == id;
            })[0];
            this.words.splice(this.words.indexOf(wordToDelete), 1);
        });
    };
}]);
