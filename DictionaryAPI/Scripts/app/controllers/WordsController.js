controllers.controller('WordsController', ['getWords', 'saveWord', 'updateWord', 'deleteWord', function (getWords, saveWord, updateWord, deleteWord) {
    var _self = this;
    _self.isAbleToAddWord = true;
    _self.search;

    var defaultName = 'WordToDefine';
    var defaultDefinition = 'Write your definition here';
    var sectionColors = new Array(0);

    getWords(function (returnedWords) {
        _self.words = returnedWords;
    });

    // private methods
    var saveEditedWord = function (ckeditorInstance) {
        var dividedId = ckeditorInstance.name.split('-');
        var prefix = dividedId[0];
        var wordAttribute = dividedId[1];
        var wordId = dividedId[2];
        
        if (wordId == '') {// if the word is new
            var newWord = _self.words.filter(function (wordItem) {
                return wordItem.name == defaultName || wordItem.definition == defaultDefinition;
            })[0];

            newWord[wordAttribute] = ckeditorInstance.getData().trimHtml();

            saveWord(newWord, function (assignedId) {
                newWord['id'] = assignedId;
            });

            _self.isAbleToAddWord = true;
        } else {// if the word is not new
            var updatedWord = _self.words.filter(function (wordItem) {
                return wordItem.id == wordId;
            })[0];

            if (updatedWord[wordAttribute] != ckeditorInstance.getData().trimHtml()) {
                updatedWord[wordAttribute] = ckeditorInstance.getData().trimHtml();
                updateWord(updatedWord);
            }
        }
    };

    var getRandomColor = function() {
        var letters = '0123456789ABCDEF'.split('');
        var color = '#';
        for (var i = 0; i < 6; i++ ) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        return color;
    }

    // public methods
    _self.getColorForSection = function (sectionId) {
        var existingSectionColor = sectionColors.filter(function (sectionColorItem) {
            return sectionColorItem.sectionId == sectionId;
        })[0];

            console.log(existingSectionColor);
        if (existingSectionColor) {
            return existingSectionColor.color;
        } else {
            sectionColors[sectionColors.length] = {
                sectionId: sectionId,
                color: getRandomColor()
            }
            return sectionColors[sectionColors.length].color;
        }
    };

    _self.makeEditable = function (id) {
        if (CKEDITOR.instances[id]) {
            return;
        }

        CKEDITOR.disableAutoInline = true;
        CKEDITOR.inline(id, {
            customConfig: '/Scripts/app/ckeditor.defaultconfig.js',
            on: {
                blur: function (event) {
                    saveEditedWord(event.sender);
                    event.sender.destroy(true);
                }
            }
        });
    };

    _self.addWord = function () {
        _self.isAbleToAddWord = false;
        _self.words[_self.words.length] = {
            name: defaultName,
            definition: defaultDefinition
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

    // for debugging
    $('#navbar').on('click', function () {
        console.log(_self.words);
    });
}]);
