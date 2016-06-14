angular.module('solutionsApp', ['ui.router','solutionsApp.user', 'solutionsApp.search'])
	.run(['$state', function($state){

		$state.go('home');

	}])
	.config(['$stateProvider', function($stateProvider){

		$stateProvider
			.state('home', {
				url: '/home',
				templateUrl: 'modules/main/views/mainPage.html'
			})
			.state('profile', {
				url: '/profile',
				templateUrl: 'modules/user/views/user-profile.html'
			})
			.state('search', {
				url: '/search',
				templateUrl: 'modules/search/views/search.html'
			})
			.state('project', {
				url: '/project',
				templateUrl: 'modules/projects/views/project-profile.html'
			})
			.state('solution',{
				url: '/solution',
				templateUrl: 'modules/projects/views/solution-list.html'
			});
	}])
	.controller('TestCtrl', ['$scope', 'authService', function($scope, authService){
		$scope.test = "I'm learnding!";

		$scope.user = {};

		$scope.login = function(){
			// alert($scope.user.login + " " + $scope.user.password);

			authService.login($scope.user.login);
		}
	}]);