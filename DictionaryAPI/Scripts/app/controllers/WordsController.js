controllers.controller('WordsController', ['getSections', 'getWords', 'saveWord', 'updateWord', 'deleteWord', function (getSections, getWords, saveWord, updateWord, deleteWord) {
    var _self = this;
    _self.sections;
    _self.words;
    _self.isAbleToAddWord = true;
    _self.search;

    var defaultName = 'WordToDefine';
    var defaultDefinition = 'Write your definition here';
    
    getSections(function(returnedSections) {
        _self.sections = returnedSections;
    });

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

    // public methods
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

    _self.getSectionById = function (id) {
        if (_self.sections) {
            return _self.sections.filter(function (sectionItem) {
                return sectionItem.id == id;
            })[0];
        }
    };
}]);
