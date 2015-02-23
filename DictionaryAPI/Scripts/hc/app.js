var app = angular.module('fanciestDictionary', [])
.controller('ListingWordsController', ['$http', function ($http) {
    //this.words = [
    //    {
    //        name: "Hello",
    //        definition: "Formal and informal farewell"
    //    },
    //    {
    //        name: "Mouse",
    //        definition: "External device for computers"
    //    },
    //    {
    //        name: "Window",
    //        definition: "Building artifact used to let light pass"
    //    }
    //];
    var instance = this;
    $http.get('http://localhost:51994/api/Dictionary').success(function (data) {
        instance.words = data;
    });
}])
.directive('dctWord', function () {
    return {
        restrict: 'E',
        templateUrl: 'Scripts/hc/Templates/dctWord.html'
    };
});
