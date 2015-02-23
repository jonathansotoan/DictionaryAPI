controllers.controller('GlobalController', ['saveWord', 'updateWord', function (saveWord, updateWord) {
    // extension methods
    if (!String.prototype.trim) {
        String.prototype.trim = function () {
            return this.replace(/^\s+|\s+$/g, '');
        }
    }

    // public methods
    this.removeCkeditorInstances = function () {
        try {
            for (instanceId in CKEDITOR.instances) {
                CKEDITOR.instances[instanceId].destroy();
                dividedId = instanceId.split('-');

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
            }
        } catch (exception) {
            // no need to worry, this is just for avoiding errors when there is no CKEDITOR instances available
        }
    };

    // private methods
    var getTextFromId = function (id) {
        return $('#' + id).text().trim();
    };
}]);
