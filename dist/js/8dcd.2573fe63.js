(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["8dcd"],{"8dcd":function(e,t,r){"use strict";r.r(t);var a=function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("div",[r("page-title-bar"),r("v-container",{attrs:{fluid:"","grid-list-xl":"","py-0":""}},[r("app-card",{attrs:{heading:e.$t("message.basicValidation"),customClasses:"mb-30"}},[r("v-form",{model:{value:e.form1.valid,callback:function(t){e.$set(e.form1,"valid",t)},expression:"form1.valid"}},[r("v-text-field",{attrs:{label:"Name",rules:e.form1.nameRules,counter:10,required:""},model:{value:e.form1.name,callback:function(t){e.$set(e.form1,"name",t)},expression:"form1.name"}}),r("v-text-field",{attrs:{label:"E-mail",rules:e.form1.emailRules,required:""},model:{value:e.form1.email,callback:function(t){e.$set(e.form1,"email",t)},expression:"form1.email"}})],1)],1),r("app-card",{attrs:{heading:e.$t("message.validationWithSubmitAndclear"),customClasses:"mb-30"}},[r("v-form",{ref:"form",attrs:{"lazy-validation":""},model:{value:e.form2.valid,callback:function(t){e.$set(e.form2,"valid",t)},expression:"form2.valid"}},[r("v-text-field",{attrs:{label:"Name",rules:e.form2.nameRules,counter:10,required:""},model:{value:e.form2.name,callback:function(t){e.$set(e.form2,"name",t)},expression:"form2.name"}}),r("v-text-field",{attrs:{label:"E-mail",rules:e.form2.emailRules,required:""},model:{value:e.form2.email,callback:function(t){e.$set(e.form2,"email",t)},expression:"form2.email"}}),r("v-select",{attrs:{label:"Item",items:e.form2.items,rules:[function(e){return!!e||"Item is required"}],required:""},model:{value:e.form2.select,callback:function(t){e.$set(e.form2,"select",t)},expression:"form2.select"}}),r("v-checkbox",{attrs:{label:"Do you agree?",rules:[function(e){return!!e||"You must agree to continue!"}],required:""},model:{value:e.form2.checkbox,callback:function(t){e.$set(e.form2,"checkbox",t)},expression:"form2.checkbox"}}),r("v-btn",{attrs:{disabled:!e.form2.valid,color:"success"},on:{click:e.submit}},[e._v("\n\t\t\t\t\t"+e._s(e.$t("message.submit"))+"\n\t\t\t\t")]),r("v-btn",{attrs:{color:"primary"},on:{click:e.clear}},[e._v(e._s(e.$t("message.clear")))])],1)],1)],1)],1)},l=[],i={data:function(){return{form1:{valid:!1,name:"",nameRules:[function(e){return!!e||"Name is required"},function(e){return e.length<=10||"Name must be less than 10 characters"}],email:"",emailRules:[function(e){return!!e||"E-mail is required"},function(e){return/^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(e)||"E-mail must be valid"}]},form2:{valid:!0,name:"",nameRules:[function(e){return!!e||"Name is required"},function(e){return e&&e.length<=10||"Name must be less than 10 characters"}],email:"",emailRules:[function(e){return!!e||"E-mail is required"},function(e){return/^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(e)||"E-mail must be valid"}],select:null,items:["Item 1","Item 2","Item 3","Item 4"],checkbox:!1}}},methods:{submit:function(){this.$refs.form.validate()&&console.log("form submit")},clear:function(){this.$refs.form.reset()}}},s=i,o=r("2877"),m=Object(o["a"])(s,a,l,!1,null,null,null);m.options.__file="FormValidation.vue";t["default"]=m.exports}}]);
//# sourceMappingURL=8dcd.2573fe63.js.map