import Vue from "vue";
import $ from "jquery";

export default Vue.extend({
	template: '#statistic',
	props: ['user'],
	data() {
		return {
			userName: this.user
		}
	},
	methods: {
		getStatistic() {
			$.ajax({
				type: 'POST',
				accepts: "application/json",
				url: 'api/userData/GetUserStatistic',
				contentType: "application/json",
				dataType: 'json',
				data: JSON.stringify(this.userName),
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