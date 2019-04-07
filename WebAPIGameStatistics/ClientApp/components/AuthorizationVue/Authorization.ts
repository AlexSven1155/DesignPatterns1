import Vue from "vue";
import $ from "jquery";

export default Vue.extend({
	template: '#authorizationVue',
	data() {
		return {
			users: []
		}
	},
	created: function(){
			var scope = this;
			$.ajax({
				url: 'api/authorization',
				type: 'GET',
				contentType: "application/json;charset=utf-8",
				success(responseData) {
					scope.users = responseData;
				},
				error(a, b, c) {
					alert(a + '\n' + b + '\n' + c);
				}
			});
	},
	methods: {
		logIn(user) {
			var scope = this;
			$.ajax({
				type: 'POST',
				accepts: "application/json",
				url: 'api/authorization',
				contentType: 'application/json',
				dataType: 'json',
				data: JSON.stringify(user),
				context: this,
				success(responseData) {
					if (responseData) {
						scope.getStatistic(user);
					} else {
						alert(responseData);
					}
				},
				error(a, b, c) {
					alert(a + '\n' + b + '\n' + c);
				}
			});
		},
		getStatistic(user) {
			$.ajax({
				type: 'POST',
				accepts: "application/json",
				url: 'api/userData/GetUserStatistic',
				contentType: "application/json",
				dataType: 'json',
				data: JSON.stringify(user),
				success(responseData) {
					if (responseData &&
						responseData.kilometersCovered &&
						responseData.kilometersCovered > 0) {
						alert(responseData.kilometersCovered);
					} else {
						alert(responseData);
					}
				},
				error(a, b, c) {
					alert(a + '\n' + b + '\n' + c);
				}
			});
		},
	}
});