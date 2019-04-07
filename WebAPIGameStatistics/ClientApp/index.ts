import Vue from "vue";
import AuthorizationComponent from "./components/AuthorizationVue/Authorization";

let v = new Vue({
	el: "#app-root",
	template: '<AuthorizationComponent />',
	components: {
		//MainTemplateComponent,
		AuthorizationComponent
	}
});