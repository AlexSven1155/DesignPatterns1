import Vue from "vue";
import HelloComponent from "./Hello";

export default Vue.extend({
	template: '#main-template',
	data() {
		return {
			name: "World"
		}
	},
	components: {
		HelloComponent
	}
});