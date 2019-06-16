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
					//users = responseData;
				},
				error(a, b, c) {
					alert(a + '\n' + b + '\n' + c);
				}
			});
	},
	methods: {
		logIn(user) {
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
						alert("OK");
					} else {
						alert(responseData);
					}
				},
				error(a, b, c) {
					alert(a + '\n' + b + '\n' + c);
				}
			});
		}
	}
});