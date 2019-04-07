import Vue from "vue";
import AuthorizationComponent from "./components/AuthorizationVue/Authorization";
import StatisticComponent from "./components/StatisticVue/Statistic";

let v = new Vue({
	el: "#app-root",
	template: '#main', //"<AuthorizationComponent />", 
	data() {
		return {
			user: ""
		}
	},
	components: {
		'authorization-comp': AuthorizationComponent,
		'statistic-comp': StatisticComponent
	},
	computed: {
		isLoggedIn() {
			return this.user !== "";
		}
	}
});