directives.directive('dctBindCkeditor', function () {
    return {
        restrict: 'A',
        require: '?ngModel',
        link: function (scope, element, attrs, ngModel) {
            if (ngModel && element[0].id) {
                console.log('here');
                var ckeditorInstance = CKEDITOR.instances[element[0].id];

                if (ckeditorInstance) {
                    ckeditorInstance.on('pasteState', function () {
                        scope.$apply(function () {
                            ngModel.$setViewValue(ckeditorInstance.getData());
                        });
                    });

                    ngModel.$render = function (value) {
                        ckeditorInstance.setData(ngModel.$viewValue);
                    };
                }
            }
        }
    };
});
