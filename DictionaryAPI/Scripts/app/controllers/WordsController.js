controllers.controller('WordsController', ['getWords', 'saveWord', 'updateWord', 'deleteWord', function (getWords, saveWord, updateWord, deleteWord) {
    var _self = this;
    _self.isAbleToAddWord = true;
    _self.search;

    getWords(function (returnedWords) {
        _self.words = returnedWords;
    });

    // private methods
    var getTextFromId = function (id) {
        return $('#' + id).html().trimHtml();
    };

    var areEqual = function (word1, word2) {
        var properties = new Array(0);

        for (property in word1) {
            if (property[0] !== '$') {
                properties[properties.length] = property;
            }
        }

        for (property in word2) {
            if (property[0] !== '$') {
                properties[properties.length] = property;
            }
        }

        properties = properties.filter(function (elem, index, self) {
            return index == self.indexOf(elem);
        });

        for (index in properties) {
            if (word1[properties[index]] !== word2[properties[index]]) {
                return false;
            }
        }

        return true;
    }

    var replaceWord = function (oldWord, newWord) {
        _self.words[_self.words.indexOf(oldWord)] = newWord;
    };

    var saveEditedWord = function (id) {
        dividedId = id.split('-');

        if (dividedId[2] == '') {// if the word is new (it does not have an id yet)
            var newWord = {
                name: getTextFromId(dividedId[0] + '-name-'),
                definition: getTextFromId(dividedId[0] + '-definition-')
            };

            saveWord(newWord, function (assignedId) {
                newWord['id'] = assignedId;
                wordWithoutId = _self.words.filter(function (wordItem) {
                    return !wordItem.id;
                })[0];
                replaceWord(wordWithoutId, newWord);
            });

            _self.isAbleToAddWord = true;
        } else {// if the word is not new
            var oldWord = _self.words.filter(function (wordItem) {
                return wordItem.id == dividedId[2];
            })[0];
            var updatedWord = {
                id: parseInt(dividedId[2]),
                name: getTextFromId(dividedId[0] + '-name-' + dividedId[2]),
                definition: getTextFromId(dividedId[0] + '-definition-' + dividedId[2])
            };

            if (!areEqual(oldWord, updatedWord)) {
                updateWord(updatedWord);
                replaceWord(oldWord, updatedWord);
            }
        }
    };

    // public methods
    _self.makeEditable = function (id) {
        if (CKEDITOR.instances[id]) {
            CKEDITOR.instances[id].destroy(true);
        }

        CKEDITOR.disableAutoInline = true;
        CKEDITOR.inline(id, {
            customConfig: '/Scripts/app/ckeditor.defaultconfig.js',
            on: {
                blur: function () {
                    saveEditedWord(id);
                }
            }
        });
    };

    _self.addWord = function () {
        _self.isAbleToAddWord = false;
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
