directives.directive('dctWord', function () {
    return {
        restrict: 'E',
        templateUrl: '/Scripts/app/templates/dctWordTemplate.html',
        scope: {
            word: '=word',
            deleteWord: '&'
        }
    };
});
