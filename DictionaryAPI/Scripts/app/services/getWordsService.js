services.factory('getWords', ['breeze', 'printHttpError', 'apiUrls', function (breeze, printHttpError, apiUrls) {
    return function (callbackFunction) {
        var manager = new breeze.EntityManager(apiUrls.apiUrl);
        var query = new breeze.EntityQuery().from(apiUrls.wordsRelativeUrl);

        manager.executeQuery(query, function (response) {
            callbackFunction(response.httpResponse.data);
        }, printHttpError);

        $('#navbar').on('click', function () {
            if (manager.hasChanges()) {
                manager.saveChanges().then(function (response) {
                    console.log('success');
                    console.log(response);
                }).fail(function (response) {
                    console.log('error');
                    console.log(response);
                });
                console.log('saved');
            } else {
                console.log('nothing to save');
            }
        });

        //breeze.EntityQuery("Words")
        //      .orderBy("name")
        //      .then(callbackFunction)
        //      .fail(printHttpError);
    };
}]);
