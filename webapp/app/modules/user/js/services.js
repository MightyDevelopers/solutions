angular.module('solutionsApp.user.services', [])
	.factory('authService', ['$http', function($http){

		var auth = {};

		auth.login = function(email){
			// return $http.post('http://solutionsai.azurewebsites.net/api/users/fafasasfd@gmail.com', {email: email});
			 $http.post('http://solutionsai.azurewebsites.net/api/Authorization/', {email: email, password: 'password'})
			 	.then(function(response){
			 		console.log(response.data + "STATUS: " + response.status);
			 	}, function(response){
			 		console.log('Error' + response.status + response.data);
			 	});
			// alert("Go go go!");
		};

		return auth;
	}]);
	// .factory('bobService', ['$scope', function($scope){

	// }]);