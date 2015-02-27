directives.directive('dctWord', function () {
    return {
        restrict: 'E',
        templateUrl: '/Scripts/app/templates/dctWordTemplate.html',
        scope: {
            word: '=',
            deleteWord: '&',
            makeEditable: '&',
            getColor: '&'
        }
    };
});
