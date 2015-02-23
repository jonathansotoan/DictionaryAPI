directives.directive('dctEditableWord', [function () {
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

    var makeUneditableAndSave = function (element) {
        CKEDITOR.instances[element.id].destroy();
        dividedId = element.id.split('-');

        if (dividedId[2] == '') {// if the word is new
            saveWord({
                name: getTextFromId(dividedId[0] + '-name-'),
                definition: getTextFromId(dividedId[0] + '-definition-')
            }, function (returnedId) {
                element.id = returnedId;
            });
        } else {// if the word is not new
            updateWord({
                id: dividedId[2],
                name: getTextFromId(dividedId[0] + '-name-' + dividedId[2]),
                definition: getTextFromId(dividedId[0] + '-definition-' + dividedId[2])
            });
        }
    };

    var makeEditable = function (element) {
        var ckeditorInstance = CKEDITOR.replace(element.id);
        ckeditorInstance.on('instanceReady', function (event) {
            setFocusAtTheEnd(event.editor);
        });

        ckeditorInstance.on('blur', function () {
            makeUneditableAndSave(element);
        });
    };

    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.on('click', function () {
                makeEditable(element);
            });
        }
    };
}]);
