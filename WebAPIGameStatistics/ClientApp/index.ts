import Vue from "vue";
import MainTemplateComponent from "./components/MainTemplate";

let v = new Vue({
	el: "#app-root",
	template: '<AppHelloComponent />',
	//render: h => h(AppHelloComponent),
	components: {
		MainTemplateComponent
	}
});