directives.directive('dctBindCkeditor', ['saveWord', 'updateWord', 'getLocalWords', function (saveWord, updateWord, getLocalWords) {
    var getTextFromId = function (id) {
        return $('#' + id).text().trim();
    };

    var findWordById = function (wordId) {
        for (word in getLocalWords.get()) {
            console.log(word.id + " == " + wordId + "? " + (word.id == wordId));
            if (word.id == wordId) {
                return word;
            }
        };
    };

    var makeUneditableAndSave = function (id) {
        CKEDITOR.instances[id].destroy();
        dividedId = id.split('-');

        //if (dividedId[2] == '') {// if the word is new
        //    saveWord({
        //        name: getTextFromId(dividedId[0] + '-name-'),
        //        definition: getTextFromId(dividedId[0] + '-definition-')
        //    });
        //} else {// if the word is not new
        //    updateWord({
        //        id: dividedId[2],
        //        name: getTextFromId(dividedId[0] + '-name-' + dividedId[2]),
        //        definition: getTextFromId(dividedId[0] + '-definition-' + dividedId[2])
        //    });
        //}
        if (dividedId[2] == '0') {// if the word is new
            var newWord = findWordById('0');
            delete newWord.id;
            saveWord(newWord, function (returnedId) {
                newWord.id = returnedId;
            });
        } else {// if the word is not new
            var updatedWord = findWordById(dividedId[2]);
            console.log(dividedId[2]);
            updateWord(updatedWord);
        }
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

    return {
        restrict: 'A',
        require: '?ngModel',
        link: function (scope, element, attrs, ngModel) {
            element.on('click', function () {
                if (!ngModel) return;

                var ckeditorInstance = CKEDITOR.replace(element[0]);

                ckeditorInstance.on('instanceReady', function (event) {
                    setFocusAtTheEnd(event.editor);
                });

                ckeditorInstance.on('pasteState', function () {
                    scope.$apply(function () {
                        ngModel.$setViewValue(ckeditorInstance.getData());
                    });
                });

                ckeditorInstance.on('blur', function () {
                    makeUneditableAndSave(element[0].id);
                });

                ngModel.$render = function (value) {
                    ckeditorInstance.setData(ngModel.$viewValue);
                };
            });
        }
    };
}]);
