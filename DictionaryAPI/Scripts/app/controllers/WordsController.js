controllers.controller('WordsController', ['getWords', 'saveWord', 'updateWord', 'deleteWord', 'getLocalWords', function (getWords, saveWord, updateWord, deleteWord, getLocalWords) {
    var _self = this;

    $('#navbar').on('click', function () {
        console.log(_self.words);
    });

    getWords(function (returnedWords) {
        getLocalWords.set(returnedWords);
        _self.words = returnedWords;
    });

    _self.addWord = function () {
        _self.words[_self.words.length] = {
            name: 'WordToDefine',
            definition: 'Write your definition here'
        };
    };

    _self.deleteWord = function (id) {
        deleteWord(id, function () {
            var wordToDelete = _self.words.filter(function (wordItem) {
                return wordItem.id == id;
            })[0];
            _self.words.splice(_self.words.indexOf(wordToDelete), 1);
        });
    };
}]);
