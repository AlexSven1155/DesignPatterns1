System.register("components/AuthorizationVue/Authorization", ["vue", "jquery"], function (exports_1, context_1) {
    "use strict";
    var vue_1, jquery_1;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (vue_1_1) {
                vue_1 = vue_1_1;
            },
            function (jquery_1_1) {
                jquery_1 = jquery_1_1;
            }
        ],
        execute: function () {
            exports_1("default", vue_1.default.extend({
                template: '#authorizationVue',
                data: function () {
                    return {
                        users: []
                    };
                },
                created: function () {
                    var scope = this;
                    jquery_1.default.ajax({
                        url: 'api/authorization',
                        type: 'GET',
                        contentType: "application/json;charset=utf-8",
                        success: function (responseData) {
                            scope.users = responseData;
                        },
                        error: function (a, b, c) {
                            alert(a + '\n' + b + '\n' + c);
                        }
                    });
                },
                methods: {
                    logIn: function (user) {
                        var scope = this;
                        jquery_1.default.ajax({
                            type: 'POST',
                            accepts: "application/json",
                            url: 'api/authorization',
                            contentType: 'application/json',
                            dataType: 'json',
                            data: JSON.stringify(user),
                            context: this,
                            success: function (responseData) {
                                if (responseData) {
                                    scope.getStatistic(user);
                                }
                                else {
                                    alert(responseData);
                                }
                            },
                            error: function (a, b, c) {
                                alert(a + '\n' + b + '\n' + c);
                            }
                        });
                    },
                    getStatistic: function (user) {
                        jquery_1.default.ajax({
                            type: 'POST',
                            accepts: "application/json",
                            url: 'api/userData/GetUserStatistic',
                            contentType: "application/json",
                            dataType: 'json',
                            data: JSON.stringify(user),
                            success: function (responseData) {
                                if (responseData &&
                                    responseData.kilometersCovered &&
                                    responseData.kilometersCovered > 0) {
                                    alert(responseData.kilometersCovered);
                                }
                                else {
                                    alert(responseData);
                                }
                            },
                            error: function (a, b, c) {
                                alert(a + '\n' + b + '\n' + c);
                            }
                        });
                    },
                }
            }));
        }
    };
});
System.register("index", ["vue", "components/AuthorizationVue/Authorization"], function (exports_2, context_2) {
    "use strict";
    var vue_2, Authorization_1, v;
    var __moduleName = context_2 && context_2.id;
    return {
        setters: [
            function (vue_2_1) {
                vue_2 = vue_2_1;
            },
            function (Authorization_1_1) {
                Authorization_1 = Authorization_1_1;
            }
        ],
        execute: function () {
            v = new vue_2.default({
                el: "#app-root",
                template: '<AuthorizationComponent />',
                components: {
                    AuthorizationComponent: Authorization_1.default
                }
            });
        }
    };
});
//# sourceMappingURL=app-bandle.js.map