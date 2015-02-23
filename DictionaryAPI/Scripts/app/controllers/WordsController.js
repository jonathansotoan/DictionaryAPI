controllers.controller('WordsController', ['getWords', 'saveWord', 'updateWord', 'deleteWord', function (getWords, saveWord, updateWord, deleteWord) {
    var _self = this;

    getWords(function (returnedWords) {
        _self.words = returnedWords;
    });

    // private methods
    var getTextFromId = function (id) {
        return $('#' + id).text().trim();
    };

    var setFocusAtTheEnd = function (editor) {
        editor.focus();

        var selection = editor.getSelection();
        var selected_ranges = selection.getRanges();
        var node = selected_ranges[0].startContainer; // selecting the starting node
        var parents = node.getParents(true);

        node = parents[parents.length - 2].getFirst();

        while (true) {
            var x = node.getNext();
            if (x == null) {
                break;
            }
            node = x;
        }

        selection.selectElement(node);
        selected_ranges = selection.getRanges();
        selected_ranges[0].collapse(false);  //  false collapses the range to the end of the selected node, true before the node.
        selection.selectRanges(selected_ranges);  // putting the current selection there
    };

    var makeUneditableAndSave = function (id) {
        CKEDITOR.instances[id].destroy();
        dividedId = id.split('-');

        if (dividedId[2] == '') {// if the word is new
            saveWord({
                name: getTextFromId(dividedId[0] + '-name-'),
                definition: getTextFromId(dividedId[0] + '-definition-')
            });
        } else {// if the word is not new
            updateWord({
                id: dividedId[2],
                name: getTextFromId(dividedId[0] + '-name-' + dividedId[2]),
                definition: getTextFromId(dividedId[0] + '-definition-' + dividedId[2])
            });
        }
    };


    // public methods
    _self.makeEditable = function (id) {
        var ckeditorInstance = CKEDITOR.replace(id);
        ckeditorInstance.on('instanceReady', function (event) {
            setFocusAtTheEnd(event.editor);
        });

        ckeditorInstance.on('blur', function () {
            makeUneditableAndSave(id);
        });
    };

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
