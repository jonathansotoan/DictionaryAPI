directives.directive('dctEditable', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.on('click', function () {
                CKEDITOR.replace(element[0].id);
            });
        }
    };
});
